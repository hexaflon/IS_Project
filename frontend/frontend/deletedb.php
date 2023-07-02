<?php

if(array_key_exists("id",$_POST)){
    $id = $_POST['id'];

    $url = "http://localhost:8080/api/file/dane/{$id}";
    
    $curl = curl_init();
    
    curl_setopt($curl, CURLOPT_URL, $url);
    curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($curl, CURLOPT_CUSTOMREQUEST, "DELETE"); 
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
    
    if ($response === "Usunięto zasób!") {
        echo "Zasób został usunięty.";
        cofnij();
    } else {
        echo $response;
        cofnij();
    }
}else{
    form();
    cofnij();
}

function form()
{
    $site = "
        <form method='post' action='deletedb.php'>
            <input type='text' name='id' placeholder='Wprowadź ID' required>
            <button type='submit'>Usuń</button>
        </form>
    ";
    echo $site;
}

function cofnij()
{
    $site = "
    <br><a href='obslugadb.php'><button>cofnij</button></a>
    ";
    echo $site;
}