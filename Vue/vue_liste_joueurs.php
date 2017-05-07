<div class=\"row\">
	<?php
		while($unJoueur=$lesJoueur->fetch(PDO::FETCH_OBJ))
		{
			echo "
					<div class=\"col-lg-4\">
						<img class=\"img-circle\" src=/".$unJoueur->lien." alt=\"Generic placeholder image\" height=\"200\" width=\"200\">
						<h2>".$unJoueur->num"</h2>
						<h3>".$unJoueur->PERSONNEL.nom" ".$unJoueur->prenom"</h3>
						<h3>".$unJoueur->POSTE.libelle"</h3>
						<p><a class=\"btn btn-default\" href=\"index.php?do=detail&idJoueur=".$unJoueur->num."\">".$unJoueur->num." role=\"button\">Voir les détails »</a></p>
					</div>
			";
		}
	?>
</div>

