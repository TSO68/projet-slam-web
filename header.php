<!-------------- AFFICHAGE DU FORMULAIRE DE CONNEXION-------------->
<div id='header'>
    <?php
        if(isset($_SESSION['login']))
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
		<center>
			<nav class="navbar navbar-inverse" style="display:inline-block; width: 62%; background-color:#0F7ED2;">
			  <div class="container-fluid">
				<div class="navbar-header">
				  <a class="navbar-brand" href="index.php"><img src ='Images/logo-racing-academy-2016.png' style="position:relative; top:-15px; left:5px;" width='62px'/></a>
				</div>
				<ul class="nav navbar-nav">
					<li class="dropdown">
						<a class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" title="Equipe" href="#">&nbsp;Equipe&nbsp;
						<span class="caret"></span></a>
							<ul class="dropdown-menu">
							  <li><a href="index.php?do=joueurs" title="Joueurs">&nbsp;Joueurs&nbsp;</a></li>
							  <li><a href="index.php?do=staff" title="Staff">&nbsp;Staff&nbsp;</a></li>
							  <li><a href="index.php?do=stade" title="Stade">&nbsp;Stade&nbsp;</a></li>
							</ul>
					</li>
					<li><a href="index.php?do=saison" title="Saison">&nbsp;Saison&nbsp;</a></li>
					<li><a href="index.php?do=connectionMembre" title="Espace membre">&nbsp;Espace membre&nbsp;</a></li>
					<li><a href="index.php?do=contacts" title="Contacts">&nbsp;Contacts&nbsp;</a></li>
				</ul>
				<ul class="nav navbar-nav navbar-right">
				  <li><a href="index.php?do=panier" title="Panier"> <span class="glyphicon glyphicon-shopping-cart"></span>&nbsp;Panier&nbsp;</a></li>
				  <li><a href="index.php?do=connexion" title="Déconnexion"><span class="glyphicon glyphicon-log-out"></span>&nbsp;Déconnexion&nbsp;</a></li>
				</ul>
			  </div>
			</nav>
		</center>
		<br>
	<?php
	}
?>