$url = "https://api.vatsim.net/v2/members/1746074/flightplans"
$url = "https://api.vatsim.net/v2/atc/online"

$result = Invoke-WebRequest -uri $url -Method Get 

$result.

while($true){
    $controllers = $result.Content | ConvertFrom-Json

    foreach($controller in $controllers)
    {
        if($controller.Callsign.Contains("TWR"))
        {
            
            $datetime = [DateTime]::ParseExact($($controller.start), 'yyyy-MM-ddTHH:mm:ssZ', [System.Globalization.CultureInfo]::InvariantCulture)

            # Calculate the time difference
            $timeDifference = (Get-Date) - $datetime

            # Format the result in HH:MM format
            $formattedResult = '{0:D2}:{1:D2}' -f $timeDifference.Hours, $timeDifference.Minutes


            $controller.Callsign + "  " + $formattedResult
            if($controller.callsign.Contains("BOS")){
                [console]::beep()
                [console]::beep()
                [console]::beep()
            }
        }

    }
    start-sleep -Seconds 30
}