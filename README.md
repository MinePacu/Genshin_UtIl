# Genshin_UtIl (가제)


## 개요
PC에서 원신을 플레이하는 사람들을 위한 PC 원신용 유틸리티이며, 레지스트리 값을 변경하지 않으면서 게임을 실행하지 않고 편하게 변경할 수 있도록 하는 것이 목적인 프로그램입니다.
<br/><br/>

## 빌드 환경 및 라이브러리
### 빌드 환경
- Visual Studio 2022
- Windows 11 22H2

### 라이브러리
- .NET 7
- Windows App SDK
<br/><br/>

## 사양
<table>
  <thead>
    <tr>
      <th colspan="3">최소 사양</th>
    </tr>
  </thead>
  <thead>
    <tr>
      <th></th>
      <th>윈도우 10</th>
      <th>윈도우 11</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>아키텍쳐</td>
      <td colspan="2" align="center">64비트</td>
    </tr>
    <tr>
      <td>버전</td>
      <td>20H1(2004) 이상</td>
      <td>버전 상관없음</td>
    </tr>
    <tr>
      <td>빌드</td>
      <td>10.0.19041.0 이상</td>
      <td>10.0.22000.1 이상</td>
    </tr>
  </tbody>
</table>
<br/>

## 기능 및 로드맵 
### 기능
<table>
  <thead>
    <tr>
      <th colspan="3">기본 기능</th>
    </tr>
  </thead>
  <thead>
    <tr>
      <th></th>
      <th>기능</th>
      <th>기타 사항</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>&check;</td>
      <td>레지스트리에서 출력 모니터, 해상도 로드 및 적용</td>
      <td></td>
    </tr>
    <tr>
      <td>&check;</td>
      <td>창 모드 변경</td>
      <td></td>
    </tr>
    <tr>
      <td>&check;</td>
      <td>모니터 새로고침</td>
      <td></td>
    </tr>
  </tbody>
  <thead>
    <tr>
      <th colspan="3">게임 실행 기능</th>
    </tr>
  </thead>
  <thead>
    <tr>
      <th></th>
      <th>기능</th>
      <th>기타 사항</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>&check;</td>
      <td>게임 파일 또는 클라이언트 실행</td>
      <td>클라이언트로 실행한 게임도 경계 없는 창 모드를 적용하는 기능을 생각 중</td>
    </tr>
    <tr>
      <td>&check;</td>
      <td>게임 파일에 인수 적용</td>
      <td></td>
    </tr>
  </tbody>
  <thead>
    <tr>
      <th colspan="3">블루투스</th>
    </tr>
  </thead>
  <thead>
    <tr>
      <th></th>
      <th>기능</th>
      <th>기타 사항</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>&check;</td>
      <td>게임 플레이 시 블루투스 자동 켜짐</td>
      <td rowspan="2">블루투스 모듈이 없으면 체크 불가하도록 설정</td>
    </tr>
    <tr>
      <td>&check;</td>
      <td>게임이 꺼지면 블루투스 자동 꺼짐</td
    </tr>
  </tbody> 
  <thead>
    <tr>
      <th colspan="3">기타 기능</th>
    </tr>
  </thead>
  <thead>
    <tr>
      <th></th>
      <th>기능</th>
      <th>기타 사항</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td></td>
      <td>paimon.moe 기원 통계 자동 제출용 링크 생성기</td>
      <td></td>
    </tr>
  </tbody>
</table>

### 프로그램 최적화
<table>
  <thead>
    <tr>
      <th colspan="3">라이브러리 내장</th>
    </tr>
  </thead>
  <thead>
    <tr>
      <th></th>
      <th>기능</th>
      <th>기타 사항</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>&check;</td>
      <td>.Net 7 내장</td>
      <td></td>
    </tr>
    <tr>
      <td>&check;</td>
      <td>Windows App SDK Runtime 내장</td>
      <td></td>
    </tr>
  </tbody>
  <thead>
    <tr>
      <th colspan="3">기타 기능</th>
    </tr>
  </thead>
  <thead>
    <tr>
      <th></th>
      <th>기능</th>
      <th>기타 사항</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>&check;</td>
      <td>MVVM 구조로 변환</td>
      <td>일부 UI를 제외하고 대부분 MVVM 구조로 변환됨<br/>단, mvvm 구조를 독학하다보니 불완전한 내용이 있을 수 있음</td>
    </tr>
  </tbody>
</table>
<br/>
