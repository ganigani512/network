<?php

header("Conect-Type: application/json; charset=UTF-8");
header("X-content-Type-Options: nosniff");

$message=' ';
$name=' ';
//tryの中に通常処理
try{
	
	if(isset( $_POST['Message'])&&isset( $_POST['username'])){
	$message=$_POST['Message'];
	$name=$_POST['username'];	
	}




	$dsn = 'mysql:dbname=chattest;host=localhost';
	$user = 'root';
	$password = '';
	$con =new PDO($dsn,$user,$password);
	
	
	$query="select max(messageid) as id from chatlogtest";
	$stmt = $con->prepare($query);
   	$stmt -> execute();
    	$result = $stmt -> fetch(PDO::FETCH_ASSOC);
    	$num = 0;

	if($result!=null){
	$num=$result["id"];
	}	
	

	$query ="insert into chatlogtest(username,messageid,message) values('";
	$query .= $name;
	$query .= "',";
	$query .= $num+1;
	$query .= ",'";
	$query .= $message; 
	$query .= "')" ;
	
	$stmt = $con->prepare($query);
    $stmt -> execute();
	$result = $stmt -> fetchAll(PDO::FETCH_ASSOC);
}
//catchの中に例外処理
catch(PDOEException $Exception){
    die('接続エラー'.$Exception->getMessage());
}

//var_dump($result);

echo $num;
?>