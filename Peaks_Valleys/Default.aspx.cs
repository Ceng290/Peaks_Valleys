using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Peaks_Valleys
{
    public partial class Default : System.Web.UI.Page
    {
        //Initialize Global variables
        int numCastle;
        string numberCastles;

        //**************************************************************************************
        //* Page_Load Event
        //**************************************************************************************
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }else{
                //Do something
            }
        }
        //**************************************************************************************
        //*
        //**************************************************************************************
        protected void Button1_Click(object sender, EventArgs e)
        {
            calculateNumCastles();
        }

        //**************************************************************************************
        //*
        //**************************************************************************************
        protected void calculateNumCastles()
        {
            try
            {
                //get the values from the textbox
                string elevation = TextBox1.Text;
                string[] myArray = elevation.Split(',');      
                int[] sequence = new int[myArray.Length];

                for (int i = 0; i < myArray.Length; i++)
                {
                    sequence[i] = int.Parse(myArray[i].ToString());
                }

                //delete any consecutive numbers that are equal  IE: [6,1,4,4,4,4,5,5,6,3] ==> [6,1,4,5,6,3]
                int temp=0;
                bool flag = false;
                List<int> termsList = new List<int>();
                for (int i = 0; i <= sequence.Length - 1; i++) {
                    if(flag == false){
                        temp = sequence[i];
                        termsList.Add(temp);
                        flag = true;
                    }
                    if (sequence[i] != temp) {
                        temp = sequence[i];
                        termsList.Add(temp);
                    }
                }

                int[] terms = termsList.ToArray();

                //Calculate the number of castles
                numCastle = getNumberofCastles(terms);

            }
            catch
            {
                //array length = 0 IE: []
                numCastle = 0;
            }
            
            numberCastles = numCastle.ToString();
            numCastles.Text = numberCastles;
        }

        //**************************************************************************************
        //* Here we determine the number of peaks and valleys from the array sequence
        //**************************************************************************************
        int getNumberofCastles(int[] terms)
        {
            int numPeaksValleyCastles = 0;
            //**************************************************************************************
            //array length = 1 IE: [1]
            //**************************************************************************************
            if (terms.Length == 1)
            {
                numPeaksValleyCastles = 1;
            }
            //**************************************************************************************
            //* array length = 2 IE: [4,1]
            //* Making the assumption that if the first number is greater than the second
            //* the first number is a peak and the second number is a valley
            //* Therefore 2 castles are needed.
            //* 
            //* If the first number == the second number then only 1 castle is needed
            //**************************************************************************************
            if (terms.Length == 2){
                if (terms[0] == terms[1])
                {
                    numPeaksValleyCastles = 1;
                }
                else
                {
                    numPeaksValleyCastles = 2;
                }
                
            }
            //*******************************************************************************************
            //*                                                                     V P V       P     
            //* array length = 3 or more IE: [6,1,4,4,4,1,2,3,4,5,5,5,4,2,1,10] ==> [6,1,4,1,2,3,4,5,4,2,1]
            //*******************************************************************************************
            if (terms.Length > 2)
            {

                for (int j = 1; j <= terms.Length - 1; j++) {

                    if (j < terms.Length - 1) {
                        if ((terms[j] < terms[j - 1]) && (terms[j] < terms[j + 1])) {
                            numPeaksValleyCastles = numPeaksValleyCastles + 1;
                        } else if ((terms[j] > terms[j - 1]) && (terms[j] > terms[j + 1])){
                            numPeaksValleyCastles = numPeaksValleyCastles + 1;
                        }
                    }
                    
                }
                
            }

            return numPeaksValleyCastles;
        }

        //**************************************************************************************
        //* Test Cases
        //**************************************************************************************        
    }
}