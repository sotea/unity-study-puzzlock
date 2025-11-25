using System;
using System.Collections.Generic;

[Serializable]
public class StageProgressData
{
    // バージョンを持っておくと将来のマイグレーションが容易
    public int version = 1;

    // クリア済みのステージID（シーン名を推奨）
    public List<string> clearedStageIds = new List<string>();
}


