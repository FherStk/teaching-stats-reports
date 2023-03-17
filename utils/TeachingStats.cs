using Npgsql;

public class TeachingStats : System.IDisposable{
    public NpgsqlConnection Connection {get; private set;}

    public TeachingStats(){
        var settings = Utils.Settings;  
        if(settings == null || settings.TeachingStats == null) throw new IncorrectSettingsException();      
        
        this.Connection = new NpgsqlConnection($"Server={settings.TeachingStats.Host};User Id={settings.TeachingStats.Username};Password={settings.TeachingStats.Password};Database=teaching-stats;");
    }

    public void Dispose()
    {
        if(Connection.State != System.Data.ConnectionState.Closed)
            Connection.Close();
        
        Connection.Dispose();
    }
}