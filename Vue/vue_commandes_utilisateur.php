<center>
    <div class ='liste'>
        <div style="overflow-x:auto;">
<?php
	 echo "<h1 style=\"font-weight: 700; color: #fff\"> Mes commandes</h1>
				<table style=\"width: 70%; border-collapse: separate; border-spacing: 30; color:#fff;\">
					 <tr align=\"center\">
						<th> Numéro de Commande </th>
						<th> Date de Commande </th>
						<th> Facture </th>
					 </tr>";

					 while ($commandes = $lesCommandes->fetch(PDO::FETCH_OBJ))
					 {
					   //Mise en forme de la date (explode() coupe en segment une chaîne)
					   $date_cmd= explode(' ',$commandes->dateCommande);
					   $date = explode('-',$date_cmd[0]);
?>
					   <tr>
						   <td> <?php echo $commandes->id?> </td>
						   <td> <?php echo $date[2],'/',$date[1],'/',$date[0]?> </td>
						   <td> <a target="_blank" href="index.php?do=facture&id=<?php echo $commandes->id ?>" ><img src ="Images/pdf.png"/></a> </td>
					   </tr>
					   <?php
					 }
				   echo "</table>";
?>
		</div>
	</div>
</center>