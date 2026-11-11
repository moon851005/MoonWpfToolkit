# MoonWpfToolkit

私有 WPF 共用函式庫，以 NuGet 套件形式發佈到 GitHub Packages。

## 專案結構

| 套件 | 說明 |
|---|---|
| `Moon.Mvvm` | 與 UI 無關的 MVVM 基礎 |
| `Moon.Mvvm.Wpf` | WPF 專用 MVVM（Converter 等） |
| `Moon.Services` | 服務層 |
| `Moon.Wpf.Controls` | 自訂控制項 |
| `MoonWpfToolkit` | 總成套件，引用以上全部；使用端只需裝這一個 |

## 版本號

由 [Nerdbank.GitVersioning](https://github.com/dotnet/Nerdbank.GitVersioning) 依 `version.json` 推算：

- `version.json` 的 `version` 給前兩碼（例如 `1.0`），第三碼為 git height（自上次改 `version.json` 以來的 commit 數）。
- 在 `develop` 或 `v*` tag 上為正式版號（如 `1.0.5`）；其他分支會帶 `-g<hash>` 後綴。
- 要升主/次版號：改 `version.json` 的 `version`，commit。

查詢目前版號：

```bash
dotnet tool install -g nbgv
nbgv get-version
```

## 發版流程

每次 push 到 `develop` 都會自動發版，不需要打 tag：

1. commit 後 `git push`。
2. GitHub Actions（`.github/workflows/publish.yml`）會 pack 五個專案並推到
   `https://nuget.pkg.github.com/moon851005/index.json`，版號由 NB.GV 自動遞增（1.0.1、1.0.2 …）。
3. 到 repo 的 Packages 頁面或 Actions log 確認版號，再回 PathOfFilter 更新 `MoonWpfToolkitVersion`。

例外：

- 只改 `.md` 檔的 commit 不會觸發。
- commit 訊息含 `[skip ci]` 時不會觸發（想推上去但不發版時用）。
- 大改版時改 `version.json` 的 `version`（如 `1.1`），之後的版號從 `1.1.0` 重新起算。
- tag 與 CI 無關，可自由用來標記重要版本（建議與實際版號一致，如 `v1.1.0`）。

## 本機打包測試

```bash
dotnet pack MoonWpfToolkit.slnx -c Release -o artifacts
```

## 使用端設定

請參考 PathOfFilter repo 的 README（`nuget.config` 需要 `read:packages` 權限的 PAT）。
