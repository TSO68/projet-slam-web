<!-------------- AFFICHAGE DU FORMULAIRE DE CONNEXION-------------->
<div id='header'>
    <?php

        //si l'utilisateur n'est pas connecté on le signal à l'utilisateur( !isset =si la variable n'est pas affectée )
        if(!isset($_SESSION['login']))
        {
            echo "&nbsp;Vous n'êtes pas connecté(e) ! ";
        }
		//Sinon on affiche son identifiant et un lien de déconnexion
        else
        {
            echo '<img src="Images/membres.png"/>';
            echo "<strong>{$_SESSION['login']}</strong>";
            echo " &nbsp;<a href='index.php?do=deconnection'><img src='Images/deconnexion.png' title='Déconnexion'/></a>";
        }
    ?> 
</div>

<!-------------- AFFICHAGE DU MENU -------------->
<?php

    //Si l'utilisateur n'est pas connecté on affiche le menu complet
    if(!isset($_SESSION['login']))
    {
		include('menu.php');
    }
    //Sinon l'utilisateur est connecté, on supprime l'accès a la page inscription
	else
	{
	?>
		<header>
			<nav class="navbar navbar-inverse">
			  <div class="container-fluid">
				<div class="navbar-header">
				  <a class="navbar-brand" href="index.php"><img src ='Images/logo-racing-academy-2016.png' style="position:relative; top:-15px; left:5px;" width='62px'/></a>
				</div>
				<ul class="nav navbar-nav">
					<li class="active"><a href="index.php" title="Accueil">&nbsp;Accueil&nbsp;</a></li>
					<li class="dropdown">
						<a class="dropdown-toggle" data-toggle="dropdown" href="#" title="Equipe">&nbsp;Equipe&nbsp;
						<span class="caret"></span></a>
							<ul class="dropdown-menu">
							  <li><a href="index.php?do=joueurs" title="Joueurs">&nbsp;Joueurs&nbsp;</a></li>
							  <li><a href="index.php?do=staff" title="Staff">&nbsp;Staff&nbsp;</a></li>
							  <li><a href="index.php?do=stade" title="Stade">&nbsp;Stade&nbsp;</a></li>
							</ul>
					</li>
					<li><a href="index.php?do=saison" title="Saison">&nbsp;Saison&nbsp;</a></li>
					<li><a href="index.php?do=connectionMembre" title="Espace membre">&nbsp;Espace membre&nbsp;</a></li>
					<li><a href="index.php?do=panier" title="Panier">&nbsp;Panier&nbsp;</a></li>
					<li><a href="index.php?do=contacts" title="Contacts">&nbsp;Contacts&nbsp;</a></li>
				</ul>
				<ul class="nav navbar-nav navbar-right">
				  <li><a href="index.php?do=connexion" title="Connexion"><span class="glyphicon glyphicon-log-out"></span>&nbsp;Déconnexion&nbsp;</a></li>
				</ul>
			  </div>
			</nav>
		</header>
	<?php
	}
?>