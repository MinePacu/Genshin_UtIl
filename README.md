# Genshin_UtIl (가제)


## 개요
PC에서 원신을 플레이하는 사람들을 위한 PC 원신용 유틸리티이며, 레지스트리 값을 변경하지 않고 편하게 변경할 수 있도록 하는 것이 목적인 프로그램입니다.


## 빌드 환경 및 라이브러리
### 빌드 환경
- Visual Studio 2022
- Windows 11 22H2

### 라이브러리
- .NET 7
- Windows App SDK


## 사양
| 최소 빌드  | 필요 프로그램  |
|:--:|:-:|
|  10.0.19041.0 빌드 이상 | .Net 7과 Windows App SDK Runtime 모두 내장 완료 |


## 기능 및 로드맵 
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
      <td></td>
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
      <td>일부 UI를 제외하고 대부분 MVVM 구조로 변환됨</td>
    </tr>
  </tbody>
</table>


## 배포에 대하여
배포는 로드맵에서 Reshade 마스터 토글 기능을 제외한 기능들이 어느 정도 개발되고 버그들이 수정되면 배포할 예정입니다.  
