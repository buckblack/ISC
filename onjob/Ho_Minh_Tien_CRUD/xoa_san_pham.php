<?php
require_once("lib/database.php");
$db=new database();
if(!isset($_GET["id"]))
{
    header("location:ds_san_pham.php");
}
else
{
    $sql="delete from san_pham where id_san_pham=?";
    $db->setQuery($sql);
    $param=array($_GET["id"]);
    $db->execute($param);
    echo "<script>alert('Xóa thành công')</script>";
    echo "<script>window.location='ds_san_pham.php'</script>";
}
?>