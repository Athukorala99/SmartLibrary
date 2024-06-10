<?php

include './components/db-connect.php';

session_start();
session_unset();
session_destroy();

header('location:login.php');


?>