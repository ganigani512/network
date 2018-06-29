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
    if(isset( $_POST['username'])){	
        $name=$_POST['username'];	
    }
    if(isset( $_POST['login'])){
        $query="insert into loginfo(charaname) values('";
        $query.=$name;
        $query.="')";
        echo "ろぐいんできたよ";
    }else{
        $query="delete from loginfo where charaname='";
        $query.=$name;
        $query.="'";
        echo "ログアウトできたよ";
    }
    $stmt = $con->prepare($query);
   	$stmt -> execute();
    $result = $stmt -> fetch(PDO::FETCH_ASSOC);
   
}
catch(PDOEException $Exception){
    die('接続エラー'.$Exception->getMessage());
}



?>