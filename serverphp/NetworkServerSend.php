<?php

header("Conect-Type: application/json; charset=UTF-8");
header("X-content-Type-Options: nosniff");


//tryの中に通常処理
try{
	$dsn = 'mysql:dbname=chattest;host=localhost';
	$user = 'root';
	$password = '';


    	//どこのDBにせつぞくするのかかな？conにDB情報を入れる？
    	
	$con =new PDO($dsn,$user,$password);
	
	$query = "select max(messageid) as id from chatlogtest";
    	$stmt = $con->prepare($query);
	$stmt ->execute();
	$result = $stmt -> fetch(PDO::FETCH_ASSOC);
	
	$max=0;
	if($result!=null){
		$max=$result["id"];
	}	
	$min=$max-30;
	if($min<=0){
		$min=0;
	}

    $query ="select * from chatlogtest where messageid between ";
	$query .=$min; 
	$query .=" and "; 
	$query .=$max; 
	$query .=" order by messageid";

	//sql内の情報でどこをとってくるのかの関数？
    //SELECT -> 目的のデータが含まれているフィールドを列挙します（どの列かってことっぽい）
    //FORM   -> SELECT句で列挙したフィールドが含まれているテーブルを列挙します。（テーブルの指定らしい）
	//どういういこと？
    //$query ="select * from chatlogtest order by messageid";//これだとlogテーブルを全部持ってくる？


    //prepare関数　execute関数の準備っぽい　 PDOStatement オブジェクトを返す
    //PDOStatement
    //同じコードの中で何回も通信してテーブルを持ってくるならやったほうがいいくらいの感じらしい。
    	
	$stmt = $con->prepare($query);
    
    //execute関数　
    $stmt -> execute();

    //fetchAll関数
    $result = $stmt -> fetchAll(PDO::FETCH_ASSOC);
	
	$message_array = array();

    foreach($result as $row){
		$message_array[] =$row["messageid"];
    	$message_array[] =$row["username"];
		$message_array[] =$row["message"];    	
	}
		//配列の文字列結合のための関数
	$test=implode(",",$message_array);


//json
}
//catchの中に例外処理
catch(PDOEException $Exception){
    die('接続エラー'.$Exception->getMessage());
}



//var_dump($json_array_text);
//var_dump($result);

echo $test;
//echo $query;

?>