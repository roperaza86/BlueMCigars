<? 
mysql_connect ("localhost", "roberto", "12345") or die (mysql_error()); 
echo "Success.. Connected to MySQL...<br />"; 
mysql_select_db("nicaragua") or die(mysql_error()); 
echo "Success.. Connected to Database... "; 
?>

