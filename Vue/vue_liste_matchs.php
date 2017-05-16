<center>
		<?php
		echo "<div class=\"liste\">
					<div class=\"row\"><br>";
			while($unMatch=$lesMatchs->fetch(PDO::FETCH_OBJ))
			{
					$date= explode("-",$unMatch->dateMatch);
					echo "<div class=\"col-lg-12\">
								<img class=\"img-responsive\" src=\"".$unMatch->logo."\"></img>
								<h3 style=\"color:#fff\">".$date[2]."/".$date[1]."/".$date[0]."</h3>
						</div>
					";
			}
			echo"	</div>
				</div>";
		?>
</center>