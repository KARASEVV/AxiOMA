<?php
$filename = "data.txt";
$fp = fopen($filename, "r");
$content = fread($fp, filesize($filename));
fclose($fp);
$pieces = explode("|", $content);
echo($content);
?>