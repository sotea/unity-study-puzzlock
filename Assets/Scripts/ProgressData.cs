using System;
using System.Collections.Generic;

[Serializable]
public class StageProgressData
{
    // バージョンを持っておくと将来のマイグレーションが容易
    public int version = 1;

    // 完了済みのステージID（シーン名を推奨）
    public List<string> completedStageIds = new List<string>();
}


