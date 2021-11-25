# 2D-movement-tutorials
a 2D movement for unity


to use the 2D movement you need to make a script you can name the script whatever you want 

use the namespace BEs.Tutorials.Movement._2D on your script 
remove the MonoBehaviour and replace it with PlayerMovement

and then you must write
            using BEs.Tutorials.Movement._2D;
            public class YourScriptName : PlayerMovement
            {
                void Update()
                {
                    movement(); 
                    //player moves
                    WallJump(); 
                    //player can walljump 
                    //need to fix walljumping
                }
            }
