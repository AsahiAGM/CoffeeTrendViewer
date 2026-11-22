## サービスコンセプトと情報公開方針

CoffeeTrendViewerは、コーヒー愛好家が自身のコーヒー体験を記録・管理するための個人用ログ機能と、蓄積されたデータをもとに地域別の嗜好傾向を可視化する機能を提供する。

本サービスは、SNSのようなユーザー間の直接的な交流や承認を目的としない。個人の記録を他者に公開することなく、他のユーザーのデータから生成された集計結果を通じて、地域ごとのコーヒー嗜好の違いを楽しめることを目指す。

### 個人ログ
- 各ユーザーのコーヒー記録は、原則として本人のみが閲覧・編集できる。
- 個別の投稿内容や投稿者情報を一般ユーザーに公開しない。
- ユーザーは自身の記録を継続的に蓄積し、コーヒーの購入履歴やテイスティング傾向を管理できる。
- 投稿データの統計利用について、利用目的と取り扱いを明確にする。

### 地域別統計
- 個人の投稿データを集計し、地域別のコーヒー嗜好傾向を可視化する。
- 一般ユーザーに公開するのは集計結果のみとし、個別投稿は公開しない。
- 少数の投稿から個人の情報が推測されることを防ぐため、最低集計件数や公開粒度を設定する。
- 統計には対象件数、集計期間、集計方法を表示する。

### サービスの基本方針
- 個人の記録を便利にすることと、集合データから新しい発見を得ることを両立させる。
- ユーザー間の競争や承認欲求を促す機能を設けない。
- 個人情報の収集を必要最小限に抑え、情報公開範囲を明確にする。
- ユーザーが安心してコーヒーの記録を蓄積できる環境を目指す。

## サービスコンセプト・プライバシー設計の追加決定

### 1. サービスコンセプト

CoffeeTrendViewerは、個人用コーヒーログと地域別の嗜好傾向の可視化を組み合わせたサービスとする。

ユーザーは自身のコーヒー体験を記録・管理し、その記録が蓄積されることで、結果的に地域別のコーヒー嗜好統計にも貢献する。

ユーザー自身は便利なコーヒーログとして利用しながら、地域別の集計結果を通じて、自分と同じようにコーヒーを楽しんでいる人々の嗜好の違いを発見できることを目指す。

SNSのようなユーザー間の直接的な交流や承認を中心とせず、コーヒーに関する情報の蓄積・管理・分析を主な価値とする。

### 2. 個人ログと情報公開方針

以下の方針を決定した。

- 個別のコーヒーログは、原則として投稿者本人のみが閲覧できる。
- 一般ユーザーには個別投稿を公開せず、地域別の集計結果のみを提供する。
- 個人ログは、ユーザー自身の購入履歴やテイスティング傾向を管理するための機能として提供する。
- 個人ログの蓄積が、地域別統計の充実にもつながる設計とする。
- 個人情報の収集は必要最小限とし、個別投稿から個人が特定されるリスクを抑える。
- 統計公開時には、少数データから個人情報が推測されることを防ぐため、最低集計件数や公開粒度を検討する。

### 3. 統計利用と投稿公開の分離

個別投稿の公開設定と、地域別統計へのデータ利用は別の概念として扱う。

将来的に個別投稿の公開機能を追加する場合も、投稿を公開することによって統計利用まで自動的に許可されたとみなさない。

統計利用については、利用目的・対象データ・取り扱いを明確にする。

### 4. 将来の拡張方針

MVPでは個別投稿の公開機能を実装しない。

ただし、将来的にユーザーが投稿ごとに公開・非公開を選択できる機能を追加できるよう、以下の設計方針を採用する。

- 投稿データとユーザー情報を論理的に分離する。
- 投稿の所有者を識別できるデータ構造にする。
- DBアクセス処理と画面表示処理を分離する。
- 個人ログの管理処理と地域別統計の生成処理を分離する。
- アクセス制御は画面上の表示制御だけに依存せず、データ取得側でも実施する。
- 将来の公開範囲設定は、統計利用の許可とは独立して管理する。
- 公開機能の追加に伴うプライバシー保護、権利侵害対応、削除要求への対応は、実装時に別途検討する。

MVPでは将来の拡張性を確保するための責務分離を優先し、現時点で不要な公開機能や複雑なアクセス制御を先行実装しない。

### 5. 今後の開発方針

次の工程ではDB設計を実施する。

特に以下のデータの関係と責務を明確にする。

1. ユーザー情報（UserProfile）
2. 個人用コーヒーログ（CoffeeLogs）
3. コーヒー豆の基本情報（CoffeeBeans）
4. 地域別統計（RegionalStatistics）

将来の複数ユーザー対応や投稿公開機能を考慮しつつ、MVPに必要な範囲に設計を限定する。

### 6. 未決定事項・今後の検討事項

- 地域別統計の分類基準（居住地域・購入地域）
- 統計利用に関するユーザーへの説明・同意方法
- 少数データの公開抑制基準
- 購入店舗情報の保存・利用範囲
- 将来的な複数ユーザー対応と共有サーバーへの移行方法

これらはDB設計および実装時に、必要性とプライバシーへの影響を考慮して決定する。

---

## 開発・学習記録（2026/11/20）

### 本日の作業：Day3 SQLite接続・テーブル作成・存在確認

#### 1. SQLite DB接続の実行検証

`Program.cs` のSQLite接続処理をWindows環境で実行し、正常に接続できることを確認した。

実行環境：
- Windows / PowerShell
- .NET SDK：10.0.404（前回確認値）
- プロジェクト：`CoffeeTrendViewer/CoffeeTrendViewer`

確認したDBファイル：
`CoffeeTrendViewer/Database/coffee.db`

実行ログで以下を確認：
- SQLite接続成功ログが出力された。
- `coffee.db` が生成された（初回確認時のファイルサイズは0 bytes）。
- ASP.NET Core Webアプリが `http://localhost:5198` で起動した。
- Content root path がプロジェクトの実行ディレクトリと一致した。

#### 2. テーブル作成処理を追加

`SqliteConnection` から `CreateCommand()` を使用して `SqliteCommand` を生成し、`CommandText` に以下のDDLを設定して実行した。

```sql
CREATE TABLE IF NOT EXISTS CoffeeLogs (
    Id INTEGER PRIMARY KEY,
    CoffeeName TEXT NOT NULL,
    Rating INTEGER
);
```

実行には `ExecuteNonQuery()` を使用した。

実行ログ：
`CoffeeLogs table created or already exists.`

これにより、テーブル作成SQLが例外なく実行されたことを確認した。

#### 3. テーブル存在確認処理を追加

SQLiteの内部構造情報を管理する `sqlite_master` をSELECTし、`CoffeeLogs` テーブルの存在を確認する処理を追加した。

```sql
SELECT name
FROM sqlite_master
WHERE type = 'table'
  AND name = 'CoffeeLogs';
```

結果取得には `ExecuteReader()` を使用し、`reader.Read()` で行を読み取った。

実行ログ：
`Verified table: CoffeeLogs`

テーブルが実際に存在することをSQL検索結果から確認できた。

#### 4. SQLite CLIの確認

PowerShellで以下を実行したが、コマンドは認識されなかった。

- `sqlite3 --version`
- `sqlite --version`

SQLite CLIは現在のWindows環境にインストールされていない（またはPATHに登録されていない）状態。

CLIを導入せず、アプリケーションの `Microsoft.Data.Sqlite` を利用してDBの検証を継続した。

### 本日確認・学習した技術概念

- `SqliteConnection`：DB接続を管理するオブジェクト。
- `Open()`：DB接続を確立する。
- `SqliteCommand`：SQL命令と実行を扱うオブジェクト。Connectionを介してSQLを実行する。
- `CommandText`：実行するSQLを設定するプロパティ。設定しただけではSQLは実行されない。
- `ExecuteNonQuery()`：主にDDL/DMLなど、結果セットを読み取らないSQLの実行に使用する。
- `ExecuteReader()`：SELECT等の結果を読み取るための実行メソッド。
- `SqliteDataReader`：SQL実行結果を読み取るオブジェクト。
- `Read()`：結果の次の行へ移動し、読み取れる行が存在するか判定する。
- `CREATE TABLE`：DB内にテーブル構造を作成するSQL。
- `IF NOT EXISTS`：同名テーブルが既に存在する場合、重複作成によるエラーを避ける。
- `sqlite_master`：SQLiteがテーブル・インデックス・ビューなどの構造情報を管理する内部テーブル。
- `PRIMARY KEY`：レコードを一意に識別する主キー。
- `NOT NULL`：NULL値を許可しない制約。
- Raw String Literal（`"""`）：C#で複数行文字列などをエスケープを抑えて記述する構文。

### 本日の検証結果

- [x] `dotnet run` によるビルド・起動成功
- [x] SQLite接続成功
- [x] DBファイル生成を確認
- [x] `CoffeeLogs` テーブル作成SQLを実行
- [x] `sqlite_master` へのSELECTでテーブル存在を確認
- [x] Webサーバー起動を確認

※ 現時点ではテーブルにデータをINSERTしていない。データ登録・取得・更新・削除は未実施。

### 次回の作業予定

1. `INSERT` によるCoffeeLogsへのデータ登録
2. SQLパラメータ（例：`@CoffeeName`）の利用と、SQL文・データを分離する理由
3. `SELECT` による登録データの取得
4. `ExecuteReader()` と `SqliteDataReader` を使った結果の読み取りを理解・検証
5. 作業終了時に当日のIT用語を抽出し、用語説明の確認問題を実施する



---

## 開発・学習記録（2026/11/21）

### 本日の作業：Day4 SQLiteへのデータ登録・取得・読み取り

#### 1. INSERTによるデータ登録

`CoffeeLogs` テーブルにテストデータを登録するSQLを追加し、実行した。

```sql
INSERT INTO CoffeeLogs (CoffeeName, Rating)
VALUES (@CoffeeName, @Rating);
```

SQLの値部分をパラメータとして指定し、`Parameters.AddWithValue()` で値を設定した。

```csharp
insertCommand.Parameters.AddWithValue("@CoffeeName", "Ethiopia");
insertCommand.Parameters.AddWithValue("@Rating", 5);
```

`ExecuteNonQuery()` の戻り値を確認する処理も追加した。今回のINSERTでは `1` が返り、1行が登録されたことを確認した。

#### 2. SQLパラメータの利用

SQL文と実際に登録する値を分離して指定する方法を確認した。

- SQL側には `@CoffeeName`、`@Rating` のようなパラメータ名を記述する。
- 値は `Parameters.AddWithValue()` で別途設定する。
- SQL文に入力値を文字列連結で直接埋め込む方式を避け、SQL Injectionのリスクを抑える。

#### 3. SELECTによる登録データの取得

次のSQLを実行し、`CoffeeLogs` のデータを取得した。

```sql
SELECT Id, CoffeeName, Rating
FROM CoffeeLogs;
```

`ExecuteReader()` で結果を読み取るための `SqliteDataReader` を取得し、`Read()` を繰り返して行単位でデータを読み取った。

```csharp
while (reader.Read())
{
    Console.WriteLine(
        $"Id[{reader["Id"]}] {reader["CoffeeName"]} rating: {reader["Rating"]}");
}
```

#### 4. 実行結果

実行時にINSERTが成功し、SELECTで登録データを取得できることを確認した。

```text
INSERT succeeded.
---CoffeeLogs---
Id[1] Ethiopia rating: 5
Id[2] Ethiopia rating: 5
Id[3] Ethiopia rating: 5
Id[4] Ethiopia rating: 5
```

複数行が表示されたのは、アプリケーション起動時にテスト用INSERTが毎回実行されるため。現状のテストコードは起動のたびにデータを追加するため、今後の検証では重複登録に注意する。テスト用INSERTは後続作業で削除または実行条件を変更する予定。

### 本日確認・学習した技術概念

- `INSERT`：テーブルに新しい行（レコード）を登録するSQL。
- `VALUES`：INSERTで登録する値を指定する句。
- SQLパラメータ：SQL文内の値をプレースホルダーとして表し、実際の値を別途設定する仕組み。
- `Parameters.AddWithValue()`：パラメータ名と値を設定するメソッド。
- `ExecuteNonQuery()`：結果セットを返さないSQLを実行し、今回のINSERTでは影響を受けた行数を戻り値で確認した。
- `SELECT`：テーブルなどからデータを取得するSQL。
- `ExecuteReader()`：SQLを実行し、結果を読み取るためのReaderを返すメソッド。
- `SqliteDataReader`：クエリ結果を行単位で読み取るためのオブジェクト。
- `Read()`：Readerの読み取り位置を次の行へ進め、行が存在するかをbool値で返す。
- SQL Injection：入力値が意図せずSQL構文として解釈され、想定外のSQL操作につながる問題。
- `SqliteConnection`：DB接続を確立・管理するオブジェクト。
- `SqliteCommand`：接続を介してSQL命令を実行するためのオブジェクト。

### 本日の検証結果

- [x] INSERT SQLを作成して実行
- [x] パラメータを使用してデータを設定
- [x] `ExecuteNonQuery()` の戻り値を確認（今回のINSERTは1行）
- [x] SELECT SQLを実行
- [x] `ExecuteReader()` と `SqliteDataReader` を使用して結果を取得
- [x] `Read()` を使った行単位の読み取りを実装
- [x] 登録データがコンソールに表示されることを確認
- [x] 当日のIT用語確認問題を実施・採点・解説

### 学習上の整理・注意点

本日の確認では、Microsoft.Data.SqliteのAPI名や細部を暗記することより、DBアクセス処理における各オブジェクト・メソッドの役割を区別することを重視した。

```text
SqliteConnection
    |
    +-- 接続を確立・管理
    |
    v
SqliteCommand
    |
    +-- SQLとパラメータを保持・実行
    |
    v
SQLiteエンジン
    |
    v
SQL実行結果
    |
    v
SqliteDataReader
    |
    +-- Read()で行単位に読み取る
```

なお、今回のINSERTは起動時に毎回実行される仮のテスト処理であり、実際のアプリケーション機能としてのデータ登録処理はまだ設計・実装していない。

### 次回の作業予定

1. 今日の実装を振り返り、テスト用INSERTの扱いを整理する（起動ごとの重複登録を防ぐ）。
2. SQLiteへの登録・取得処理の流れを整理する。
3. DB設計に着手し、MVPに必要なテーブル・項目・関係を検討する。
4. UserProfile、CoffeeLogs、CoffeeBeans、RegionalStatisticsのデータの関係と責務を検討する。
5. 必要に応じて今日の概念を復習し、用語確認を継続する。

---

## 開発・学習記録（2026/11/22）

### 本日の作業：Day5 CoffeeLogの入力・モデル化・DB登録／取得処理の整理

#### 1. 入力値の検証

コーヒー名と評価値の入力を検証する処理を実装・確認した。

- CoffeeName：空文字・空白のみの入力を拒否し、入力文字列をTrimして扱う。
- Rating：`int.TryParse()` で整数への変換を検証し、1～5の範囲内であることを確認する。
- 入力・検証とDB処理を分け、検証済みデータを後続処理へ渡す方針を整理した。

#### 2. CoffeeLogモデルの作成

`Models` ディレクトリに `CoffeeLog` クラスを作成し、CoffeeNameとRatingをまとめるデータモデルとして使用した。

```csharp
public class CoffeeLog
{
    public string CoffeeName { get; }
    public int Rating { get; }

    public CoffeeLog(string coffeeName, int rating)
    {
        CoffeeName = coffeeName;
        Rating = rating;
    }
}
```

コンストラクタで値を受け取り、読み取り専用プロパティを通じて保持する構成を確認した。オブジェクト生成時に初期状態を設定すること、および値を後から変更できない設計の意図について学習した。

#### 3. 入力からモデルを生成する処理

入力・検証後の値から `CoffeeLog` を生成する `GetCoffeeLog()` の役割を整理した。

入力処理、検証、データモデル生成、DB登録をそれぞれ独立した責務として扱い、処理の流れを分ける方針を確認した。

#### 4. INSERT処理の整理

`InsertLog(SqliteConnection, CoffeeLog)` を用いて、CoffeeLogモデルの値をSQLパラメータに設定し、DBへ登録する処理を整理した。

- SQL文と入力データを分離するパラメータ化クエリを継続使用。
- `ExecuteNonQuery()` の戻り値で影響行数を確認する。
- 登録処理を入力処理から分離し、ConnectionとCoffeeLogを引数として受け取る形を検討・実装した。

#### 5. SELECT・Readerからモデル一覧を生成

`GetCoffeeLogs(SqliteConnection)` を実装し、SELECT結果を読み取り、`List<CoffeeLog>` として扱う流れを確認した。

- `ExecuteReader()` でReaderを取得する。
- `Read()` で行単位に読み取る。
- `GetOrdinal()` でSELECT結果内の列名から列位置を取得する。
- 読み取った値をCoffeeLogインスタンスに変換し、リストへ追加する。

SELECT句の列順を変更した検証でも、`GetOrdinal()` を使うことで列名に対応した値を取得できることを確認した。

#### 6. DB制約とアプリケーション側検証

アプリケーション側の入力検証と、DB側の制約が異なる目的を持つことを整理した。

- アプリケーション側検証：ユーザーへ適切なエラーを返し、不正な入力を登録処理へ進ませない。
- DB制約：アプリケーションの別処理や予期しない経路からの書き込みも含め、DB内のデータ整合性を守る。

`NOT NULL` や `CHECK` 制約の用途を確認した。既存テーブルに対して `CREATE TABLE IF NOT EXISTS` を再実行しても、既存テーブルの定義は更新されないため、後から制約を追加する場合にはスキーマ変更・移行が必要になる点を確認した。

#### 7. NULL・リソース管理・接続再利用に関する学習

- DB列がNULLを許可する場合、Readerの値を型付きアクセサで取得する前にNULLかどうかを確認する必要がある。`IsDBNull()` の利用、およびモデル側をnullableにする設計を検討。
- `using` と `Dispose()` はReader・Command・Connectionなどが所有するリソースを確実に解放するための仕組みであり、Managed Memoryを直接GCから解放する操作ではない。
- Garbage Collector（GC）はManaged Memoryの回収を担う。DisposeとGCは役割が異なる。
- Connection Poolingは接続の再利用によって接続確立の負荷を抑える仕組みとして概要を確認。詳細仕様は今後の復習対象。

### 本日の検証・進捗

- [x] 入力値の空・空白チェックとTrim
- [x] Ratingの整数変換と1～5の範囲チェック
- [x] CoffeeLogモデルの作成（コンストラクタ、読み取り専用プロパティ）
- [x] 入力・検証済みデータからモデルを生成する処理の整理
- [x] CoffeeLogを引数にしたINSERT処理の整理
- [x] SELECT結果をCoffeeLogのリストに変換する処理
- [x] `GetOrdinal()` による列名ベースの読み取りと、SELECT列順変更の検証
- [x] DB制約とアプリケーション検証の役割の違いを確認
- [x] NULL、Dispose／GC、Connection Poolingの概要を学習
- [x] 当日の理解確認・IT用語記述課題を実施

### 本日の理解確認結果

- 理解確認テスト：23/30（76.7%）
- IT用語記述課題：20/24（83.3%）

復習優先項目：
- Constructorの実行タイミング（INSERT時ではなく、インスタンス生成時）
- `ExecuteNonQuery()` の戻り値は影響を受けた行数
- Readerからの型付き取得、NULLの扱い
- DisposeとGCの役割の区別
- Connection Poolingの仕組みとConnectionの所有・管理

### 未完了・注意事項

- 起動時に実行されるテスト用INSERTを整理し、アプリ起動のたびに重複データが追加される状態を解消する。
- NULLを許可するRating列と、読み取り時／モデル側でのNULLの扱いを決める。
- DB制約追加時の既存DBスキーマ移行方法を検討する。
- Dispose／GCとConnection Poolingについて、理解確認で不足した内容を復習する。
- 学習・開発の所要時間は本日未報告のため未記録。

### 次回の作業予定

1. 現在の実装と入力からDB登録・取得までの処理フローを振り返る。
2. 起動時のテスト用INSERTを削除または実行条件を分離し、起動時に不要な重複登録が起きないようにする。
3. NULLの扱いを確認し、DBスキーマとモデル・Reader処理の整合性を取る。
4. CoffeeLogの登録・取得をユーザー操作に基づく基本フローへ整理する。
5. 今日の理解確認で誤答・不足した項目を短く復習する。

