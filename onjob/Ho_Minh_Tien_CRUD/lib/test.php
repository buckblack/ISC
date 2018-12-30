<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
</head>
<body>
    <?php
        require("database.php");
        $db=new database();
        $sql="select * from mon_an";
        $db->setQuery($sql);
        $kq= $db->loadAllRows();
        foreach ($kq as $k) {
            echo $k->ma_mon;
        }
    ?>
</body>
</html>