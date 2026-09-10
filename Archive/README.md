# Archive

Items removed from the main structure during the reorganization.

> ⚠️ **Nothing here is deleted.** Everything is preserved. Review before permanently removing anything.

| Sub-folder | What's inside | Why it's here |
|---|---|---|
| `Old-README.md` | Previous root README (generic template) | Replaced by the new root `README.md` |
| `Duplicates/` | `C# Project/` (exact copy of `1264623/EvidanceXm`), `1264623.zip` (duplicate zip), `forloo_whileloop-nested/`, `forloo_whileloop-for-loop-copy/` | Exact/logical duplicates of kept sources |
| `Broken-Samples/` | `tryCatch`, `TryCatchC`, `PrimeNumber` | Code does not compile / logic never works |
| `Empty-Experiments/` | `rectangle`, `Rectangle1`, `lopptricks`, `Evidance` | Empty or near-empty experiments |
| `Empty-Dirs/` | `age claculator`, `tan`, `test05`, `gyfytd`, plus empty shells `Csharp-Work`, `LeetCode C Sharp Problem`, `Algorithms Notes for Professionals` | Empty directories preserved for safety |
| `Junk-Project/` | `%V%/` | VS Code default project (name is a placeholder) |
| `LeetCode-Duplicates/` | `189.RotateArray` (empty stub), `242.ValidAnagram` (alternate version) | Older/smaller duplicates of kept solutions |

## To restore something

```powershell
 Move-Item "Archive\Duplicates\C# Project" "01-CSharp\SampleProjects\"   # example
```

## Note

- Build output (`bin/`, `obj/`, `.vs/`) inside these folders is git-ignored; it can be deleted
  locally anytime — it regenerates on build. The source files are the only important content here.