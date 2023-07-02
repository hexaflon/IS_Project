<?php
echo "<center><b1>Obsługa bazy danych</b1><br>";
echo "<a href='importdb.php'><button>import z csv</button></a>";
echo "<a href='export.php'><button>export z bazy</button></a>";
echo "<a href='danezdb.php'><button>showdb</button></a>";
echo "<a href='deletedb.php'><button>deletedb</button></a>";
echo "</center>";
cofnij();




function cofnij(){
    $site = "<center>
    <br><a href='logowanie.php'><button>cofnij</button></a></center>
    ";
    echo $site;
}