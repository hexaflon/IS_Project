<?php

$url = "http://localhost:8080/api/file/importcsv";

$curl = curl_init();

curl_setopt($curl, CURLOPT_URL, $url);
curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
curl_setopt($curl, CURLOPT_CUSTOMREQUEST, "PUT");
session_start();
$token = $_SESSION['token'];
curl_setopt($curl, CURLOPT_HTTPHEADER, array(
    'Content-Type: application/json',  
    'Authorization: Bearer ' . $token  
));
$response = curl_exec($curl);

if (curl_errno($curl)) {
    echo 'Błąd: ' . curl_error($curl);
}

curl_close($curl);

if ($response === "Dane zaimportowane do bazy!") {
    echo "Zaimportowane dane";
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