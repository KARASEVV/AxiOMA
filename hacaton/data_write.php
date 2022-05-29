<?php
$el = $_POST["el"];
$id = $_POST["id"];
$filename = "data.txt";
$fp = fopen($filename, "r");
$content = fread($fp, filesize($filename));
fclose($fp);
$pieces = explode("|", $content);
$pieces[$el]=$id;
$itog = implode("|", $pieces);
//echo $itog;
file_put_contents($filename, $itog);
?>