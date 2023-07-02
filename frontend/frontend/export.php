<?php

$url = "http://localhost:8080/api/file/exportdb";

$curl = curl_init();

curl_setopt($curl, CURLOPT_URL, $url);
curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
curl_setopt($curl, CURLOPT_POST, true); 

$response = curl_exec($curl);

if (curl_errno($curl)) {
    echo 'Błąd: ' . curl_error($curl);
}

curl_close($curl);

if ($response === "Dane wyexportowane z bazy!") {
    echo "wyexportowano dane";
    cofnij();
} else {
    echo $response;
    cofnij();
}

function cofnij()
{
    $site = "
    <br><a href='obslugadb.php'><button>cofnij</button></a>
    ";
    echo $site;
}