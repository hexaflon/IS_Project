<?php
cofnij();
load();
session_start();
$token = $_SESSION['token'];

$url = "http://localhost:8080/api/file/getdata";
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

$data = json_decode($response, true);

if (is_array($data)) {
    //tworzenie tablicy z danymi dla wykresu
    $labels = [];
    $values = [];

    foreach ($data as $row) {
        $labels[] = $row['rok'] . '-' . $row['miesiac'];
        $values[] = $row['wartosc'];
    }

    //generowanie wykresu, biblioteka Chart.js
    echo '<canvas id="myChart"></canvas>';
    echo '<script src="https://cdn.jsdelivr.net/npm/chart.js"></script>';
    echo '<script>';
    echo 'var ctx = document.getElementById("myChart").getContext("2d");';
    echo 'var myChart = new Chart(ctx, {';
    echo '    type: "line",';
    echo '    data: {';
    echo '        labels: ' . json_encode($labels) . ',';
    echo '        datasets: [{';
    echo '            label: "Wartość",';
    echo '            data: ' . json_encode($values) . ',';
    echo '            backgroundColor: "rgba(0, 123, 255, 0.2)",';
    echo '            borderColor: "rgba(0, 123, 255, 1)",';
    echo '            borderWidth: 1';
    echo '        }]';
    echo '    },';
    echo '    options: {';
    echo '        scales: {';
    echo '            y: {';
    echo '                beginAtZero: true';
    echo '            }';
    echo '        }';
    echo '    }';
    echo '});';
    echo '</script>';

	echo '<br>';
    echo '<table>';
    echo '<tr>';
    echo '<th>ID</th>';
    echo '<th>Rok</th>';
    echo '<th>Miesiąc</th>';
    echo '<th>Wartość</th>';
    echo '</tr>';

    foreach ($data as $row) {
        echo '<tr>';
        echo '<td>' . $row['id'] . '</td>';
        echo '<td>' . $row['rok'] . '</td>';
        echo '<td>' . $row['miesiac'] . '</td>';
        echo '<td>' . $row['wartosc'] . '</td>';
        echo '</tr>';
    }

    echo '</table>';
} else {
    echo 'Błąd w otrzymanych danych.';
}

function load()
{
    $site = "
    <!DOCTYPE html>
    <html lang='en'>
    <head>
        <meta charset='UTF-8'>
        <title>XML</title>
        <style>
            body {
                text-align: center;
                margin: auto;
            }

            table {
                margin: 0 auto;
                border-collapse: collapse;
            }

            th, td {
                border: 1px solid black;
                padding: 5px;
            }
        </style>
    </head>
    <body>
        <h1>Dane z DB</h1>
        <h3>Dane przedstawiające ilość zarejestrowanych bezrobotnych w Polsce w poszczególnych latach i miesiącach.</h3>
    </body>
    </html>
    ";
    echo $site;
}

function cofnij()
{
    $site = "<center>
    <br><a href='obslugadb.php'><button>cofnij</button></a></center>
    ";
    echo $site;
}
?>
