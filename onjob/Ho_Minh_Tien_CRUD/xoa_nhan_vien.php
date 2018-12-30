<?php
require_once("lib/database.php");
$db=new database();
if(!isset($_GET["id"]))
{
    header("location:ds_nhan_vien.php");
}
else
{
    $sql="delete from nhan_vien where id_nhan_vien=?";
    $db->setQuery($sql);
    $param=array($_GET["id"]);
    $db->execute($param);
    echo "<script>alert('Xóa thành công')</script>";
    echo "<script>window.location='ds_nhan_vien.php'</script>";
}
?>