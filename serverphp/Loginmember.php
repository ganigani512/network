<?php

header("Conect-Type: application/json; charset=UTF-8");
header("X-content-Type-Options: nosniff");
$name="";
$login="";

try{
    $dsn = 'mysql:dbname=chattest;host=localhost';
    $user = 'root';
	$password = '';
	$con =new PDO($dsn,$user,$password);
    
    $query="select * from loginfo";
   
    $stmt = $con->prepare($query);
   	$stmt -> execute();
    $result = $stmt -> fetchAll(PDO::FETCH_ASSOC);
   
    $loginmember = array();
    foreach($result as $row){
		$loginmember[] =$row["charaname"];
    }
    $member=implode(",",$loginmember);
    echo $member;
}
catch(PDOEException $Exception){
    die('接続エラー'.$Exception->getMessage());
}



?>