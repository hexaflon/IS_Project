<?php

session_start();
if(array_key_exists("token",$_SESSION) && !array_key_exists("Logout",$_GET)){
    logged_in();
}
else if(array_key_exists("Username",$_GET)){

    login($_GET["Username"],$_GET["Password"]);
}
else if(array_key_exists("Logout",$_GET)){
    session_unset();
    create_login();
}
else{
    create_login();
}


function logged_in(){
    


$site ='
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
    
            <tr>
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
                    <a href="obslugadb.php">
                        <button>import/export z bazy</button>
                    </a>
                </td>
                <td>
                </tr>
                <tr>
                <br>
                <form method = "get" action="logowanie.php">
                <input type="hidden" name="Logout" value="Logout" id="Logout">
                <br>
                <button type="submit" name"submit">Wyloguj</button>
                </form>
                <table>
                </td>
            </tr>
        </table>
    </ul>
</body>
</html>';
echo $site;
}


function login($Username,$Password){
    $url = "http://localhost:8080/api/users/authenticate/";
    $data = ["Username"=>$Username,"Password"=>$Password];

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

    //var_dump($responseData);
    if(!array_key_exists("errors",$responseData) && !array_key_exists("message",$responseData) ){
    $token = $responseData["token"];
    //echo $token;
    $_SESSION['id'] = $responseData['id'];
    $_SESSION['token'] = $token;
    $_SESSION['Username'] = $Username;
    logged_in();
    }
    else if(array_key_exists("message",$responseData)){
        create_login();
        echo $responseData["message"];
        
    }
    else{
        create_login();
        $errors = $responseData["errors"];

        foreach ($errors as $klucz => $wartość) {
            
            echo $wartość[0]."<br>";
        }
        
    }
}





/*
$url = "http://localhost:8080/api/users/prime/";
$jsonData = json_encode($data);
$curl = curl_init();

// Opcje cURL.
curl_setopt($curl, CURLOPT_URL, $url);
curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
curl_setopt($curl, CURLOPT_HTTPHEADER, array(
    'Content-Type: application/json',  // Określ typ zawartości jako JSON.
    'Authorization: Bearer ' . $token  // Przesyłaj token JWT w nagłówku.
));

$response = curl_exec($curl);

if (curl_errno($curl)) {
    echo 'Błąd: ' . curl_error($curl);
}

curl_close($curl);
$responseData = json_decode($response, true);

var_dump($responseData);
var_dump($response);
*/

?>
<?php
function create_login(){
    $site = 

    "<!DOCTYPE html>".
"<html lang='en'>".
"<head>"."<meta charset='UTF-8'><title>Lista użytkowników</title><style>"
        ."body{
            text-align:center;
            margin: auto;
        }
        </style>".
"</head>
<body>
    
    <h1>Lista użytkowników</h1>
    <h2>Username i Password </h6>
    <h6>Andrzej Andrzej</h6>
    <h6>Piotrek Piotrek</h6>
    <h6>Ania Ania</h6>

    <ul>
        <form method = 'get' action='logowanie.php'>
        <input type='text' name='Username' id='Username' placeholder='Username'><br>
        <input type='password' name='Password' id='Password' placeholder='Password'><br>
        <button type='submit' name'submit'>Zaloguj</button>
        
        </form>
        <a href='menu.php'><button>cofnij</button></a>
    </ul>
</body>
</html>";
echo $site;

}
