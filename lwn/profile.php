<?php 
    include './components/db-connect.php';
    include './components/header.php'; 

    session_start();

   
    $user_id = $_SESSION['user_id'];
    if (!isset($user_id)) {
      header('location:login.php');
      exit();
    }


?>

   
<?php
        $select_profile = $conn->prepare("SELECT * FROM `user_form` WHERE id = ?");
        $select_profile->execute([$user_id]);
        if($select_profile->rowCount() > 0){
            $fetch_profile = $select_profile->fetch(PDO::FETCH_ASSOC);
?>
    
    <div class="u-p container">
        <div class="profile-box tech">
            <div class="p-i">
                <img src="./images/login.jpg" alt="" class="p-img">
            </div>
            <h2 class="p-category"><?= $fetch_profile['regno']; ?></h2>
            <a href="#" class="p-title"><?= $fetch_profile['name']; ?></a>
            <span class="p-date"><?= $fetch_profile['email']; ?></span>
            <span class="p-date"><?= $fetch_profile['contact']; ?></span>
            <div class="bt">
                <a href="u-profile.php" class="p-btn">Update</a>
                <a href="logout.php" class="p-btn">logout</a>
            </div>
        </div>
    </div>

<?php
    }else{
          
    }
?>

<?php 
    include './components/footer.php'; 
?>