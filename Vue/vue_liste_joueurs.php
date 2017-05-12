<center>
		<?php
			$poste="";
			$tab=0;
			while($unJoueur=$lesJoueurs->fetch(PDO::FETCH_OBJ))
			{
				if( $unJoueur->libelle != $poste){
					if($tab>0){
						echo "</div>";
					}
					$poste=$unJoueur->libelle;
					if($poste=="Milieu de terrain"){
						$posteCorrige="Milieux de terrain";
					}
					else{
						$posteCorrige=$poste."s";
					}
					echo "<h1>".$posteCorrige."</h1>
						<br>
						<div class=\"row\" style=\"display:inline-block; width: 62%;\">";
					$tab=$tab+1;
				}
					echo "
							<div class=\"col-lg-4\">
								<a href=\"index.php?do=detail&idJoueur=".$unJoueur->num."\">
									<img class=\"img-circle\" src=".$unJoueur->lien.">
								</a>
								<h2 style=\"color:#0c64a8\">".$unJoueur->num."</h2>
								<h3>".$unJoueur->nom." ".$unJoueur->prenom."</h3>
							</div>
					";
			}
		?>
</center>