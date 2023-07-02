<?php

$url = "http://localhost:8080/api/users/";

$curl = curl_init();

curl_setopt($curl, CURLOPT_URL, $url);
curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);

$response = curl_exec($curl);

if (curl_errno($curl)) {
    echo 'Błąd: ' . curl_error($curl);
}

curl_close($curl);

$users = json_decode($response, true);

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Lista użytkowników</title>
    <style>
        body{
            text-align:center;
            margin: auto;
        }
        </style>
</head>
<body>
    <h1>Lista użytkowników</h1>
    <ul>
        <a href = "logowanie.php">test</a>
    </ul>
</body>
</html>