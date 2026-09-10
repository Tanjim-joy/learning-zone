$root = 'e:\Ply_ground\Learing Zone Notes'
$out = @()
$files = Get-ChildItem -LiteralPath $root -Recurse -Force -File | Where-Object {
    $_.FullName -notlike '*\.git\*' -and $_.FullName -notlike '*\bin\*' -and $_.FullName -notlike '*\obj\*' -and $_.FullName -notlike '*\.vs\*'
}

$out += '=== ALL NON-BUILD FILES (relative path|size bytes) ==='
$files | ForEach-Object {
    $out += ($_.FullName.Replace($root, '') + '|' + $_.Length)
}

$content = [string]::Join([char]13 + [char]10, $out)
[System.IO.File]::WriteAllText('C:\Users\WALTON\AppData\Local\Temp\lz-audit\out2_utf8.txt', $content, [System.Text.Encoding]::UTF8)