<?php
if (!empty($_POST["pass"])) {
	$pass = $_POST["pass"];
	$data = $_POST["data"];
	if($pass == "okxmsk#ppkoxmjs")
	{		
		if($data == "shopxyz")
		{
			$ch = curl_init();
			curl_setopt($ch, CURLOPT_URL, "http://127.0.0.1:6605/apps/107.15.1.612744830/stop?_method=post");
			curl_setopt($ch, CURLOPT_HEADER, 0);
			curl_exec($ch);
			curl_close($ch);
			
			$ch = curl_init();
			curl_setopt($ch, CURLOPT_URL, "http://127.0.0.1:6605/apps/1056.1.1.612744837/stop?_method=post");
			curl_setopt($ch, CURLOPT_HEADER, 0);
			curl_exec($ch);
			curl_close($ch);
			
			echo("reloaded success");
		}
		else if($data == "authxyz")
		{
			$ch = curl_init();
			curl_setopt($ch, CURLOPT_URL, "http://127.0.0.1:6605/apps/1012.1.1.612598578/stop?_method=post");
			curl_setopt($ch, CURLOPT_HEADER, 0);
			curl_exec($ch);
			curl_close($ch);

			echo("reloaded success");
		}
	}
}
?>