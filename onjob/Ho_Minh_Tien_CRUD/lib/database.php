<?php
class database
{
    protected $pdo = NULL;
    protected $sql = '';
    protected $sta = NULL;        
    
    public function __construct() 
	{
        try
		{
			$this->pdo = new PDO('mysql:host=localhost;dbname=ql_ban_hang','root','');
        	$this->pdo->query('set names "utf8"');
		}
		catch(PDOException $ex)
		{
			echo $ex->getMessage();
			die();	
		}
    }
    
    public function setQuery($sql) {
        $this->sql = $sql;
    }
    
    public function execute($options=array()) {
        $this->sta = $this->pdo->prepare($this->sql);
        if($options) {
            for($i=0;$i<count($options);$i++) {
                $this->sta->bindParam($i+1,$options[$i]);
            }
        }
        $this->sta->execute();
        return $this->sta;
    }
    
    public function loadAllRows($options=array()) {
        if(!$options) {
            if(!$result = $this->execute())
                return false;
        }
        else {
            if(!$result = $this->execute($options))
                return false;
        }
        return $result->fetchAll(PDO::FETCH_OBJ);
    }
    
    public function loadRow($option=array()) {
        if(!$option) {
            if(!$result = $this->execute())
                return false;
        }
        else {
            if(!$result = $this->execute($option))
                return false;
        }
        return $result->fetch(PDO::FETCH_OBJ);
    }
    
    public function disconnect() {
        $this->sta=NULL;
		$this->pdo = NULL;
    }
}
?>  