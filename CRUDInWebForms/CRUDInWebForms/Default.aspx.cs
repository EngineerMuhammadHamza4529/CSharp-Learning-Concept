using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            LoadRecord();
        }


    }

    SqlConnection con = new SqlConnection("Data Source=DESKTOP-1NHQSUD\\MSSQLSERVER2022;Initial Catalog=ProgrammingDB;Integrated Security=True");
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        con.Open();
        SqlCommand comm = new SqlCommand("Insert into StudentInfo_Tab values('" + int.Parse(TextBox1.Text) + "','" + TextBox2.Text + "','" + DropDownList1.SelectedValue + "','" + double.Parse(TextBox3.Text) + "','" + TextBox4.Text + "')", con);
        comm.ExecuteNonQuery();
        con.Close();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted');", true);
        LoadRecord();
    }

    void LoadRecord()
    {
        SqlCommand comm = new SqlCommand("Select * from StudentInfo_Tab", con);
        SqlDataAdapter d = new SqlDataAdapter(comm);
        DataTable dt = new DataTable();
        d.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand comm = new SqlCommand("Update StudentInfo_Tab set StudentName = '" + TextBox2.Text + "',Address = '" + DropDownList1.SelectedValue + "',Age = '" + double.Parse(TextBox3.Text) + "',Contact = '" + TextBox4.Text + "' where StudentID = '" + int.Parse(TextBox1.Text) + "'", con);
        comm.ExecuteNonQuery();
        con.Close();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated');", true);
        LoadRecord();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand comm = new SqlCommand("Delete StudentInfo_Tab where StudentID = '" + int.Parse(TextBox1.Text) + "'", con);
        comm.ExecuteNonQuery();
        con.Close();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Deleted');", true);
        LoadRecord();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlCommand comm = new SqlCommand("Select * from StudentInfo_Tab where StudentID = '"+int.Parse(TextBox1.Text) + "'", con);
        SqlDataAdapter d = new SqlDataAdapter(comm);
        DataTable dt = new DataTable();
        d.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        //con.Open();
        //SqlCommand comm = new SqlCommand("Select * from StudentInfo_Tab where StudentID = '" + int.Parse(TextBox1.Text) + "'", con);
        //SqlDataReader r = new comm.ExecuteReader();
        //while (r.Read())
        //{
        //    TextBox2.Text = r.GetValue(1).ToString();
        //}

        con.Open();
        SqlCommand comm = new SqlCommand("Select * from StudentInfo_Tab where StudentID = @StudentID", con);
        comm.Parameters.AddWithValue("@StudentID", int.Parse(TextBox1.Text));
        SqlDataReader r = comm.ExecuteReader();
        while (r.Read())
        {
            TextBox2.Text = r.GetValue(1).ToString();
            DropDownList1.SelectedValue = r.GetValue(2).ToString();
            TextBox3.Text = r.GetValue(3).ToString();
            TextBox4.Text = r.GetValue(4).ToString();
        }
        r.Close();
        con.Close();

    }
}