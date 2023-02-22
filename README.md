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
|  10.0.19041.0 빌드 이상 | Windows App SDK (내장 예정)  |


## 로드맵
- 기본 기능
  |   | 기능 | 기타 사항 |
  |:--:|:--:|:--:|
  | <ul><li>[x]</li></ul> | 레지스트리에서 출력 모니터, 해상도 로드 및 적용 |  |
  | <ul><li>[x]</li></ul>| 창 모드 변경 |  |
  | <ul><li>[x]</li></ul> | 모니터 새로고침 |  |

- Reshade 보조 기능 (기능 추가 고려 중)
  |   | 기능 | 기타 사항 |
  |:--:|:--:|:--:|
  | <ul><li>[ ]</li></ul> | ReShade 마스터 토글 |  |

- 게임 실행 기능
  |   | 기능 | 기타 사항 |
  |:--:|:--:|:--:|
  | <ul><li>[x]</li></ul> | 게임 파일 또는 클라이언트 실행 |x |
  | <ul><li>[x]</li></ul> | 게임 파일에 인수 적용 |  |

- 기타 기능
  - 블루투스
  |   | 기능 | 기타 사항 |
  |:--:|:--:|:--:|
  | <ul><li>[ ]</li></ul> | 게임 플레이 시 블루투스 자동 켜짐 |  |
  | <ul><li>[ ]</li></ul> | 게임이 꺼지면 블루투스 자동 꺼짐 | |

- 라이브러리
  |   | 기능 | 기타 사항 |
  |:--:|:--:|:--:|
  | <ul><li>[x]</li></ul> |  .NET 7 내장 |  |
  | <ul><li>[x]</li></ul> | Windows App SDK 내장 | 처음 프로그램을 열었을 때, 자동으로 설치하도록 함 |

- 기타
  |   | 기능 | 기타 사항 |
  |:--:|:--:|:--:|
  | <ul><li>[ ]</li></ul> | MVVM 구조로 변경 |  |
