# Puzzlock

Unity 6.2 で制作した 2D パズルゲームです。  
鍵（Key）を対応する錠前（Lock）にぶつけて解除し、すべての鍵をゴールに届けるとステージクリアになります。

## ゲーム概要

- **ジャンル**: 2D パズル
- **操作**: キーボード（WASD / 矢印キー）または ゲームパッド
- **目的**: 各ステージで色の合った鍵と錠前をマッチさせ、すべての鍵をゴールへ運ぶ

## シーン構成

| シーン | 説明 |
|--------|------|
| `HomeScene` | タイトル・ステージ選択画面 |
| `Stage1` | ステージ 1 |
| `Stage2` | ステージ 2 |
| `Stage3` | ステージ 3 |

## 主なスクリプト

| スクリプト | 役割 |
|------------|------|
| `PlayerController` | プレイヤーの移動・アニメーション制御 |
| `StageManager` | ステージ内のクリア判定 |
| `Lock` | 鍵と錠前の色マッチング・解除処理 |
| `StageSelect` | ステージ選択ボタンの動作・完了表示 |
| `ProgressManager` | ステージ進捗の管理（シングルトン） |
| `SaveSystem` | JSON によるセーブ/ロード |
| `ProgressData` | 進捗データの構造定義 |
| `ButtonManager` | 汎用 UI ボタン（ホームへ戻る、リスタート） |
| `BgmManager` | BGM 再生・音量管理 |
| `BgmVolumeSlider` / `SfxVolumeSlider` | 音量スライダー UI |
| `HomeMenuController` / `HomeOption` | ホーム画面のメニュー・オプション |

## セーブデータ

進捗は JSON 形式で保存されます。

- **Windows**: `%USERPROFILE%\AppData\LocalLow\<CompanyName>\<ProductName>\progress.json`
- **macOS**: `~/Library/Application Support/<CompanyName>/<ProductName>/progress.json`

`ProgressManager.I.ResetAllProgress()` を呼び出すとセーブデータを削除できます。

## 動作環境

- Unity 6.2 以降
- Universal Render Pipeline (URP)
- Input System パッケージ
- TextMesh Pro

## ビルド

1. Unity Hub からプロジェクトを開く
2. **File > Build Settings** でプラットフォームを選択
3. **Build** または **Build And Run** を実行

ビルド済みファイルは `Builds/Windows/` に出力されます。

## ライセンス

このプロジェクトは学習目的で作成されています。

