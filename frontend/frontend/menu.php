<?php

$url = "http://localhost:8080/api/users/menu/";

$curl = curl_init();

curl_setopt($curl, CURLOPT_URL, $url);
curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);


$response = curl_exec($curl);


if (curl_errno($curl)) {
    echo 'Błąd: ' . curl_error($curl);
}

curl_close($curl);

$users = json_decode($response, true);

$username = $users[0]['username'];
$password = "Andrzej";

$data = array(
    "Username" => $username,
    "Password" => $password
);

$url = "http://localhost:8080/api/users/authenticate/";
$jsonData = json_encode($data);
$curl = curl_init();

curl_setopt($curl, CURLOPT_URL, $url);
curl_setopt($curl, CURLOPT_POST, 1); 
curl_setopt($curl, CURLOPT_POSTFIELDS, $jsonData);
curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
curl_setopt($curl, CURLOPT_HTTPHEADER, array(
    'Content-Type: application/json', 
));

$response = curl_exec($curl);

if (curl_errno($curl)) {
    echo 'Błąd: ' . curl_error($curl);
}

curl_close($curl);

$responseData = json_decode($response, true);



$token = $responseData["token"];




$url = "http://localhost:8080/api/users/prime/";
$jsonData = json_encode($data);
$curl = curl_init();


curl_setopt($curl, CURLOPT_URL, $url);
curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
curl_setopt($curl, CURLOPT_HTTPHEADER, array(
    'Content-Type: application/json',  
    'Authorization: Bearer ' . $token  
));

$response = curl_exec($curl);

if (curl_errno($curl)) {
    echo 'Błąd: ' . curl_error($curl);
}

curl_close($curl);
$responseData = json_decode($response, true);


?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Menu</title>
    <style>
        body{
            text-align:center;
            margin: auto;
        }
        table{
            border: 0px;
        }
        </style>
</head>
<body>
    
    <h1>Menu</h1>
    <ul>
        <table>
            <tr>
                <td>
                    
                </td>
                <td>
                    <a href="XML.php">
                    <button>Test XML</button>
                    </a>
                </td>
                <td>
                    <a href ="JSON.php">
                    <button>Test Json</button>
                    </a>
                    
                </td>
                <td>
                    <a href='obslugadb.php'>
                        <button>import/export z bazy</button>
                    </a>
                </td>
            </tr>
        </table>
    </ul>
</body>
</html>