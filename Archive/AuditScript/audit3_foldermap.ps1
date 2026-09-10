$root = 'e:\Ply_ground\Learing Zone Notes'
$script:out = @()

Write-Host 'Scanning...'

function MapDir($dir) {
    $entries = Get-ChildItem -LiteralPath $dir -Force | Sort-Object { $_.Name.ToLower() }
    foreach ($e in $entries) {
        if ($e.Name -in @('bin','obj','.vs','Properties')) { continue }
        if ($e.Name -eq '.git') { continue }
        $rel = $e.FullName.Replace($root, '')
        if ($e.PSIsContainer) {
            $inner = Get-ChildItem -LiteralPath $e.FullName -Force | Where-Object { $_.PSIsContainer -and $_.Name -notin @('bin','obj','.vs','Properties') }
            if ($inner.Count -eq 0) {
                $cs = Get-ChildItem -LiteralPath $e.FullName -Force -File | Where-Object { $_.Extension -in '.cs','.md','.txt' -and $_.Name -ne 'AssemblyInfo.cs' }
                $sizes = ($cs | ForEach-Object { $_.Name + '(' + $_.Length + ')' }) -join ', '
                $script:out += ('DIR ' + $rel + '  [' + $sizes + ']')
            } else {
                $script:out += ('GRP ' + $rel)
                MapDir $e.FullName
            }
        } else {
            if ($e.Name -ne 'AssemblyInfo.cs') {
                $script:out += ('    ' + $rel + '  |' + $e.Length)
            }
        }
    }
}

MapDir ($root + '\Csharp-Work')

$content = [string]::Join([char]13 + [char]10, $script:out)
[System.IO.File]::WriteAllText('C:\Users\WALTON\AppData\Local\Temp\lz-audit\out3_map.txt', $content, [System.Text.Encoding]::UTF8)
Write-Host ('DONE ' + $script:out.Count + ' lines')