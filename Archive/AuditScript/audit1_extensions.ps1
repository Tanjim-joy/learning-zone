$root = 'e:\Ply_ground\Learing Zone Notes'
$out = @()
$files = Get-ChildItem -LiteralPath $root -Recurse -Force -File | Where-Object { $_.FullName -notlike '*\.git\*' }

$out += '=== EXTENSION SUMMARY (excluding .git) ==='
$files | Group-Object Extension | Sort-Object -Property Count -Descending | ForEach-Object {
    $total = [math]::Round((($_.Group | Measure-Object -Property Length -Sum).Sum)/1MB, 2)
    $out += ($_.Name + '|' + $_.Count + '|' + $total + ' MB')
}

$out += ''
$out += '=== FILE CATEGORY SUMMARY ==='
$src = $files | Where-Object { $_.Extension -in '.cs', '.go', '.js', '.ts', '.jsx', '.tsx', '.py', '.java', '.c', '.cpp', '.html', '.css', '.sql', '.php', '.rb' }
$notes = $files | Where-Object { $_.Extension -in '.md', '.txt', '.doc', '.docx', '.pdf' }
$proj = $files | Where-Object { $_.Extension -in '.csproj', '.sln', '.json', '.yaml', '.yml', '.toml', '.ini', '.config', '.gitignore', '.gitattributes', '.editorconfig' }
$build = $files | Where-Object { $_.FullName -like '*\bin\*' -or $_.FullName -like '*\obj\*' -or $_.FullName -like '*\.vs\*' -or $_.FullName -like '*\__pycache__\*' -or $_.Extension -in '.exe', '.dll', '.pdb', '.suo', '.cache', '.a', '.so', '.dylib', '.bin', '.lock' }
$out += ('SOURCE_CODE|' + $src.Count + '|' + [math]::Round((($src | Measure-Object -Property Length -Sum).Sum)/1MB, 2) + ' MB')
$out += ('NOTES_DOCS|' + $notes.Count + '|' + [math]::Round((($notes | Measure-Object -Property Length -Sum).Sum)/1MB, 2) + ' MB')
$out += ('PROJECT_CFG|' + $proj.Count + '|' + [math]::Round((($proj | Measure-Object -Property Length -Sum).Sum)/1MB, 2) + ' MB')
$out += ('BUILD_CACHE|' + $build.Count + '|' + [math]::Round((($build | Measure-Object -Property Length -Sum).Sum)/1MB, 2) + ' MB')

$out += ''
$out += '=== ALL NOTES (.md) files ==='
$files | Where-Object { $_.Extension -eq '.md' } | ForEach-Object {
    $out += ($_.FullName.Replace($root, '') + '|' + $_.Length + ' bytes')
}

$content = [string]::Join([char]13 + [char]10, $out)
[System.IO.File]::WriteAllText('C:\Users\WALTON\AppData\Local\Temp\lz-audit\out1_utf8.txt', $content, [System.Text.Encoding]::UTF8)