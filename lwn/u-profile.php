<<?php 
    include './components/db-connect.php';
    include './components/header.php'; 

    session_start();

   
    $user_id = $_SESSION['user_id'];
    if (!isset($user_id)) {
      header('location:login.php');
      exit();
    }

    

?>
?php 
    include './components/db-connect.php';
    include './components/header.php'; 

    session_start();

   
    $user_id = $_SESSION['user_id'];
    if (!isset($user_id)) {
      header('location:login.php');
      exit();
    }

    

?>

   
    <div class="u-p container">
        <form class="form" method="POST">
            <p class="form-title">Update your Password</p>
             <div class="input-container">
                <input type="password" placeholder="Old Password" name="old_pass" maxlength="10" oninput="this.value = this.value.replace(/\s/g, '')"/>
           </div>
           <div class="input-container">
               <input type="password" placeholder="New Password" name="new_pass" maxlength="10" oninput="this.value = this.value.replace(/\s/g, '')"/>
            </div>
            <div class="input-container">
                <input type="password" placeholder="Confirm Password" name="confirm_pass" maxlength="20" oninput="this.value = this.value.replace(/\s/g, '')"/>
            </div>
            <button type="submit" name="update" class="submit">
                Update
            </button>
            <button type="submit" class="submit">
                <a href="profile.php">Go back</a>
            </button>
        </form>
    </div>

<?php 
    include './components/footer.php'; 
?>