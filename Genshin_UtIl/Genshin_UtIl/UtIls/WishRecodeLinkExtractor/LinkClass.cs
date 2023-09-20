using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Web;

namespace Genshin_UtIl.UtIls.WishRecodeLinkExtractor
{
    public static class LinkClass
    {
        /// <summary>
        /// <see href="https://paimon.moe">페이몬 모에</see> 사이트에서 이용하는 원신 가챠 기록 링크를 로드합니다.
        /// </summary>
        /// <param name="Link">링크를 로드하기 위한 인스턴스</param>
        /// <returns>링크가 로드되었으면 <c>true</c>, 아니면 <c>false</c>를 반환합니다.</returns>
        public static bool TryGetGenshinGachaLink(out string Link)
        {
            if (File.Exists(ConfIg.Instance.GenshInFolder.GenshInFolder) == false)
            {
                Link = string.Empty;
                return false;
            }

            else
            {
                string cachefile = Path.Combine(ConfIg.Instance.GenshInFolder.GenshInFolder, @"\webCaches\2.15.0.0\Cache\Cache_Data\data_2");
                string tmpfile = Path.Combine(Path.GetTempPath(), @"\ch_data_2");

                File.Copy(cachefile, tmpfile, true);

                string GachaLink = File.ReadAllLines(tmpfile)
                                        .Reverse()
                                        .SkipWhile(line => line.Contains(@"https://webstatic-sea.hoyoverse.com/genshin/event/e20190909gacha-v2") == false)
                                        .TakeWhile(line => line.Contains("game_biz=hk4e_global"))
                                        .ToArray()[0]
                                        .Split("1/0/")[1]
                                        .Split("game_biz")[0]
                                        + "game_biz=hk4e_global";

                if (TestUrl(GachaLink, false))
                {
                    Link = GachaLink;
                    return true;
                }

                else
                {
                    Link = string.Empty;
                    return false;
                }
            }
        }


        static bool TestUrl(string url, bool IsServerChina)
        {
            var Url = new UriBuilder(url);
            Url.Path = "event/gacha_info/api/getGachaLog";
            if (IsServerChina == false)
                Url.Host = "hk4e-api-os.hoyoverse.com";
            else
                Url.Host = "hk4e-api.mohoyo.com";
            Url.Fragment = "";

            var _params = HttpUtility.ParseQueryString(Url.Query);
            _params.Set("lang", "ko");
            _params.Set("gacha_type", "301");
            _params.Set("size", "5");
            _params.Add("lang", "ko_kr");

            Url.Query = _params.ToString();
            var apiUrl = Url.Uri.AbsoluteUri;

            var ps = PowerShell.Create()
                            .AddCommand("Invoke-WebRequest")
                            .AddParameter("Uri", apiUrl)
                            .AddParameter("ContentType", "application/json")
                            .AddParameter("UseBasicParsing")
                            .AddParameter("TimeoutSec", 10)
                            .AddCommand("ConvertFrom-json")
                            .Invoke();

            return Convert.ToInt32(ps[0].Members["retcode"].Value) == 0;
        }
    }
}
