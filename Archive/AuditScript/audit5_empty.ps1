$root = 'e:\Ply_ground\Learing Zone Notes'
$out = @()

$out += '=== EMPTY DIRECTORIES ==='
$dirs = Get-ChildItem -LiteralPath $root -Recurse -Force -Directory | Where-Object { $_.FullName -notlike '*\.git\*' }
$empty = 0
foreach ($d in $dirs) {
    $children = Get-ChildItem -LiteralPath $d.FullName -Force
    if ($children.Count -eq 0) {
        $empty++
        $out += $d.FullName.Replace($root, '')
    }
}
$out += ('TOTAL_EMPTY_DIRS|' + $empty)

$content = [string]::Join([char]13 + [char]10, $out)
[System.IO.File]::WriteAllText('C:\Users\WALTON\AppData\Local\Temp\lz-audit\out5_empty.txt', $content, [System.Text.Encoding]::UTF8)
Write-Host ('DONE ' + $empty + ' empty dirs')