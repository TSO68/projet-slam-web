<?php
session_start();
?>

<HTML>
    <HEAD>
        <TITLE>Projet Slam</TITLE>
		<meta http-equiv="content-type" content="text/html; charset=utf-8" />
        <!--Feuilles de style globale-->
		<link rel = "stylesheet" type = "text/css" href = "CSS/bootstrap-3.3.7-dist/css/bootstrap.css">
		<link href="CSS/animate.min.css" rel="stylesheet">
		<link href="CSS/bootstrap-dropdownhover.min.css" rel="stylesheet">
		<!--Favicon-->
		<link rel="shortcut icon" href="Images/logo-racing-academy-2016.png" />
         <!--Fonctions JavaScript-->
		<!--<script type="text/javascript">$(document).ready(function(){$("div.messConf").delay(2000).fadeOut();});</script>-->
		<script type="text/javascript" src="JS/jquery.min.js"></script>
		<script type="text/javascript" src="JS/bootstrap.min.js"></script>
		<script type="text/javascript" src="JS/bootstrap-dropdownhover.min.js"></script>
	</HEAD>

     
    <BODY>
		<body background="Images/bg-9-full.png">
        <div id ='page'>
            <!--En-tête-->
            <?php include('header.php');?>
            <!--Contenu de la page-->
			
			<?php
					
				if(!isset($_GET['do'])){
			?>
					<br>
					 <div id='content'>
						<center>
							<div class="container" style="margin-top: -20px; display:inline-block; width: 62%;padding-left:0px;padding-right:0px;">
							  <div id="myCarousel" class="carousel slide" data-ride="carousel">
								<!-- Indicators -->
								<ol class="carousel-indicators">
								  <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
								  <li data-target="#myCarousel" data-slide-to="1"></li>
								  <li data-target="#myCarousel" data-slide-to="2"></li>
								</ol>

								<!-- Wrapper for slides -->
								<div class="carousel-inner" style="border-radius:10px">

								  <div class="item active">
									<img src="Images/rc2.jpg" alt="Bienvenue" style="width:100%;">
									<div class="carousel-caption">
									  <h3>Bienvenue!</h3>
									  <p>Nous sommes heureux de vous accueillir sur le site offciel du FC SIO, nous espèrons que vous passerez un bon moment sur ce dernier, en vous remerçiant de votre passage!</p>
									</div>
								  </div>
								  
								  <div class="item">
									<img src="Images/rc3.jpg" alt="Supporters" style="width:100%;">
									<div class="carousel-caption">
									  <h3>Des supporters toujours au rendez-vous</h3>
									  <p>Avec un cop de supporters très soudés et toujours derrière leurs équipe, le FC SIO est l'une des équipes les plus suivies du championnat! Merci à tous pour votre soutien!</p>
									</div>
								  </div>

								  <div class="item">
									<img src="Images/rc1.jpg" alt="Dernier match" style="width:100%;">
									<div class="carousel-caption">
									  <h3>Victoire!</h3>
									  <p>Nos joueurs sont allés s'imposer sur la pelouse du RC SISR lors de leurs dernière rencontre 3-0! Félicitations à eux!</p>
									</div>
								  </div>
							  
								</div>

								<!-- Left and right controls -->
								<a class="left carousel-control" href="#myCarousel" data-slide="prev" style="border-radius:10px">
								  <span class="glyphicon glyphicon-chevron-left"></span>
								  <span class="sr-only">Previous</span>
								</a>
								<a class="right carousel-control" href="#myCarousel" data-slide="next" style="border-radius:10px">
								  <span class="glyphicon glyphicon-chevron-right"></span>
								  <span class="sr-only">Next</span>
								</a>
							  </div>
							</div>
						</center>
					</div>
			<?php		
				}
				else {
					switch($_GET['do']){
						//exemple
						case 'joueurs':{
							include("Controleur/ctrl_liste_joueurs.php");
							break;
						}
						case 'detail':{
							include("Controleur/ctrl_detail_joueur.php");
							break;
						}
						case 'staffs':{
							include("Controleur/ctrl_liste_staff.php");
							break;
						}
						case 'detailStaff':{
							include("Controleur/ctrl_detail_staff.php");
							break;
						}
						case 'stade':{
							include("Vue/vue_stade.php");
							break;
						}
						case 'contacts':{
							include("Vue/vue_contacts.php");
							break;
						}
					}
				}
			?>			
           
            <!--Pied de page-->
         <?php include('footer.php');?>
        </div>
  </BODY>
</HTML>