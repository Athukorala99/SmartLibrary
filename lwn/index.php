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

    <section class="home" id="home">
        <div class="home-text container">
            <h2 class="home-title">Smart Library</h2>
            <span class="home-subtitle">Your gateway to knowledge.</span>
        </div>
    </section>

    <div class="post-filter container">
        <span class="filter-item active-filter" data-filter="all">All</span>

        <?php
            $select_rack = $conn->prepare("SELECT * FROM `rack`");
            $select_rack->execute();
            if($select_rack->rowCount() > 0){
                while($fetch_rack = $select_rack->fetch(PDO::FETCH_ASSOC)){
        ?>
        
        <span class="filter-item" data-filter="<?= $fetch_rack['category']; ?>" > <?= $fetch_rack['category']; ?> </span>
        <?php
              }
            }else{
              echo '<p class="empty">no rack added yet!</p>';
            }
        ?>
    </div>
    
    <div class="post container">
        <?php
            $select_books = $conn->prepare("SELECT * FROM `book` WHERE `status` = 'Available'");
            $select_books->execute();
            if($select_books->rowCount() > 0){
                while($fetch_books = $select_books->fetch(PDO::FETCH_ASSOC)){
        ?>
            <div class="post-box <?= $fetch_books['category']; ?>">
            <img src="data:image/jpeg;base64,<?= base64_encode($fetch_books['bpic']); ?>" class="post-img" />
                <h2 class="category"><?= $fetch_books['category']; ?></h2>
                <a href="#" class="post-title"><?= $fetch_books['bname']; ?></a>
                <span class="post-date"><?= $fetch_books['bid']; ?></span>
                <p class="post-description"><?= $fetch_books['discription']; ?>.</p>
                <div class="profile">
                    <img src="./images/pro.jpg" alt="" class="profile-img">
                    <span class="profile-name"><?= $fetch_books['writer']; ?></span>
                </div>
            </div>
        <?php
              }
            }else{
              echo '<p class="empty">no products added yet!</p>';
            }
        ?>
    </div>

<?php 
    include './components/footer.php'; 
?>