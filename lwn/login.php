<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Trend Blogger</title>
    <!-- Box-icon -->
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>
    <link rel="stylesheet" href="./css-js/style.css">
</head>
<body>

<?php
    include './components/db-connect.php';

    session_start();
    if (isset($_POST['login'])) {

        $email = filter_var($_POST['email'], FILTER_SANITIZE_EMAIL);  // Sanitize email
        $password = $_POST['pass']; // Access password directly (caution)

        $select_user = $conn->prepare("SELECT * FROM `user_form` WHERE email = ?");
        $select_user->execute([$email]);

        if ($select_user->rowCount() == 1) {
            $fetch_user_info = $select_user->fetch(PDO::FETCH_ASSOC);
            if ($password === $fetch_user_info['password']) {  // Direct password comparison (caution)
                $_SESSION['user_id'] = $fetch_user_info['id'];
                header('location:index.php');
            } else {
                $message = 'Incorrect password.'; // More specific error message
            }
        } else {
            $message = 'Email not found.';  // More specific error message
        }
    }

?>

    
    <div class="login-container">
        <form class="form"action="login.php" method="POST">
            <p class="form-title">LOGIN</p>
             <div class="input-container">
                <input type="email" name="email" placeholder="Enter email" required oninput="this.value = this.value.replace(/\s/g, '')" />
           </div>
           <div class="input-container">
               <input type="password" name="pass" placeholder="Enter password" required oninput="this.value = this.value.replace(/\s/g, '')" />
            </div>
            <button type="submit" name="login" class="submit">
                login
            </button>
        </form>
    </div>

  

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.1/jquery.min.js" integrity="sha512-aVKKRRi/Q/YV+4mjoKBsE4x3H+BkegoM/em46NNlCqNTmUYADjBbeNefNxYV7giUp0VxICtqdrbqU7iVaeZNXA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="./css-js/main.js"></script>
</body>
</html>