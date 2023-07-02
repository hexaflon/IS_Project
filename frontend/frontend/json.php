<?php
if (array_key_exists("import", $_GET)) {

    load();
    import();
    cofnij();

} else if (array_key_exists("export", $_GET)) {
    load();
    export();
    cofnij();

} else if (array_key_exists("show", $_GET)) {
    load();
    cofnij();
    show();

} else {
    load();
    cofnij();
}

function import()
{
    $url = "http://localhost:8080/api/file/importjson";
    $curl = curl_init();
    curl_setopt($curl, CURLOPT_URL, $url);
    curl_setopt($curl, CURLOPT_POST, 1);
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
    $responseData = json_decode($response, true);
    echo $responseData;
    echo ("<br>");

}

function export()
{
    $url = "http://localhost:8080/api/file/exportjson";
    $curl = curl_init();
    curl_setopt($curl, CURLOPT_URL, $url);
    curl_setopt($curl, CURLOPT_POST, 1);
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
    $responseData = json_decode($response, true);
    echo ("<br>");
}

function show()
{
    $jsonUrl = 'http://localhost:8080/api/file/getjson';
    $limit = 1000;
    $count = 0;

    $ch = curl_init();
    curl_setopt($ch, CURLOPT_URL, $jsonUrl);
    curl_setopt($ch, CURLOPT_POST, 1);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
    session_start();
    $token = $_SESSION['token'];
    curl_setopt($ch, CURLOPT_HTTPHEADER, array(
        'Content-Type: application/json',
        'Authorization: Bearer ' . $token
    ));
    $response = curl_exec($ch);
    curl_close($ch);

    if ($response !== false) {
        $json = json_decode($response, true);

        if ($json !== null) {
            echo "<table style='margin: 0 auto;'>";
            echo "<tr>";
            echo "<th>ID</th>";
            echo "<th>Rok</th>";
            echo "<th>Ilość kobiet</th>";
            echo "<th>Ilość mężczyzn</th>";
            echo "<th>Wszyscy</th>";
            echo "</tr>";

            foreach ($json as $item) {
                echo "<tr>";
                echo "<td>" . $item['Id'] . "</td>";
                echo "<td>" . $item['Rok'] . "</td>";
                echo "<td>" . $item['Ilosc_kobiet'] . "</td>";
                echo "<td>" . $item['Ilosc_mezczyzn'] . "</td>";
                echo "<td>" . $item['Wszyscy'] . "</td>";
                echo "</tr>";

                $count++;
                if ($count === $limit) {
                    break;
                }
            }

            echo "</table>";
        } else {
            echo 'Błąd parsowania danych JSON.';
        }
    } else {
        echo 'Błąd pobierania pliku JSON.';
    }
}


function load()
{
    $site = "
    <!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <title>json</title>
    <style>
        body{
            text-align:center;
            margin: auto;
        }
        table{
            margin: 0 auto;
            border-collapse: collapse;
        }
        th, td{
            border: 1px solid black;
            padding: 8px;
        }
    </style>
</head>
<body>
    <h1>Operacje na pliku json</h1>
    <table>
    <tr>
    <td>
    <form method='get' action='json.php'>
        <input type='hidden' name='import' value='import' id='import'>
        <button type='submit' name='submit'>Import</button>
    </form>
    </td>
    <td>
    <form method='get' action='json.php'>
        <input type='hidden' name='export' value='export' id='export'>
        <button type='submit' name='submit'>Export</button>
    </form>
    </td>
    <td>
    <form method='get' action='json.php'>
        <input type='hidden' name='show' value='show' id='show'>
        <button type='submit' name='submit'>Show</button>
    </form>
    </td>
    </tr>
    </table>
</body>
</html>
    ";
    echo $site;
}

function cofnij()
{
    $site = "
    <a href='logowanie.php'>
    <button>Cofnij</button>
    </a>
    ";
    echo $site;
}

?>
