using UnityEngine;

namespace ET
{
    [FriendClass(typeof(UserInputComponent))]
    public static class UserInputComponentSystem
    {
         /// <summary>
        /// 检查按键抬起
        /// </summary>
        public static void CheckKeyUp(this UserInputComponent self)
        {
            if (Input.GetMouseButtonUp(0))
            {
                self.LeftMouseDown = false;
                self.LeftMouseUp = true;
            }
            
            if (Input.GetMouseButtonUp(1))
            {
                self.RightMouseDown = false;
                self.RightMouseUp = true;
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                self.ADown_long = false;
                self.ADouble = false;
                self.AUp = true;
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                self.DDown_long = false;
                self.DDouble = false;
                self.DUp = true;
            }

            if (Input.GetKeyUp(KeyCode.J))
            {
                self.JDown_long = false;
                self.JDouble = false;
                self.JUp = true;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                self.SpaceDown_long = false;
                self.SpaceUp = true;
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                self.WDown_long = false;
                self.WUp = true;
            }

            if (Input.GetKeyUp(KeyCode.Q))
            {
                self.QDown_long = false;
                self.QUp = true;
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                self.EDown_long = false;
                self.EUp = true;
            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                self.RDown_long = false;
                self.RUp = true;
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                self.SDown_long = false;
                self.SUp = true;
            }
        }

        /// <summary>
        /// 检查按键落下
        /// </summary>
        public static void CheckKeyDown(this UserInputComponent self)
        {
            if (Input.GetMouseButtonDown(0))
            {
                self.LeftMouseDown = true;
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                self.RightMouseDown = true;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                self.ADown = true;

                if ((self.currentTime - self.ALastClickTime) / 1000f <= 0.5f)
                {
                    self.ADouble = true;
                }
                else
                {
                    self.ADouble = false;
                }

                self.ALastClickTime = self.currentTime;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                self.WDown = true;

                if ((self.currentTime - self.WLastClickTime) / 1000f <= 0.5f)
                {
                    self.WDouble = true;
                }
                else
                {
                    self.WDouble = false;
                }

                self.WLastClickTime = self.currentTime;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                self.QDown = true;

                if ((self.currentTime - self.QLastClickTime) / 1000f <= 0.5f)
                {
                    self.QDouble = true;
                }
                else
                {
                    self.QDouble = false;
                }

                self.QLastClickTime = self.currentTime;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                self.EDown = true;

                if ((self.currentTime - self.ELastClickTime) / 1000f <= 0.5f)
                {
                    self.EDouble = true;
                }
                else
                {
                    self.EDouble = false;
                }

                self.ELastClickTime = self.currentTime;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                self.RDown = true;

                if ((self.currentTime - self.RLastClickTime) / 1000f <= 0.5f)
                {
                    self.RDouble = true;
                }
                else
                {
                    self.RDouble = false;
                }

                self.RLastClickTime = self.currentTime;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                self.DDown = true;

                if ((self.currentTime - self.DLastClickTime) / 1000f <= 0.5f)
                {
                    self.DDouble = true;
                }
                else
                {
                    self.DDouble = false;
                }

                self.DLastClickTime = self.currentTime;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                self.SDown = true;

                if ((self.currentTime - self.SLastClickTime) / 1000f <= 0.5f)
                {
                    self.SDouble = true;
                }
                else
                {
                    self.SDouble = false;
                }

                self.SLastClickTime = self.currentTime;
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                self.JDown = true;

                if ((self.currentTime - self.JLastClickTime) / 1000f <= 0.5f)
                {
                    self.JDouble = true;
                }
                else
                {
                    self.JDouble = false;
                }

                self.JLastClickTime = self.currentTime;
            }
        }

        /// <summary>
        /// 检查按键输入
        /// </summary>
        public static void CheckKey(this UserInputComponent self)
        {
            if (Input.GetKey(KeyCode.A))
            {
                self.ADown_long = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                self.DDown_long = true;
            }

            if (Input.GetKey(KeyCode.J))
            {
                self.JDown_long = true;
            }

            if (Input.GetKey(KeyCode.Q))
            {
                self.QDown_long = true;
            }

            if (Input.GetKey(KeyCode.S))
            {
                self.SDown_long = true;
            }


            if (Input.GetKey(KeyCode.Space))
            {
                self.SpaceDown_long = true;
            }

            if (Input.GetKey(KeyCode.W))
            {
                self.WDown_long = true;
            }

            if (Input.GetKey(KeyCode.E))
            {
                self.EDown_long = true;
            }

            if (Input.GetKey(KeyCode.R))
            {
                self.RDown_long = true;
            }
        }

        public static void ResetAllState(this UserInputComponent self)
        {
            self.LeftMouseDown = false;
            self.LeftMouseUp = false;
            
            self.RightMouseDown = false;
            self.RightMouseUp = false;

            self.AUp = false;
            self.ADown = false;

            self.DDown = false;
            self.DUp = false;

            self.JUp = false;
            self.JDown = false;

            self.WUp = false;
            self.WDown = false;

            self.SpaceUp = false;
            self.SpaceDown = false;

            self.QUp = false;
            self.QDown = false;

            self.SUp = false;
            self.SDown = false;

            self.EUp = false;
            self.EDown = false;

            self.RUp = false;
            self.RDown = false;
        }
    }
    
    public class UserInputComponentStartSystem : AwakeSystem<UserInputComponent>
    {
        public override void Awake(UserInputComponent self)
        {
            self.startTime = TimeHelper.ClientNow();
        }
    }
    
    public class UserInputComponentUpdateSystem : UpdateSystem<UserInputComponent>
    {
        public override void Update(UserInputComponent self)
        {
            self.ResetAllState();

            self.currentTime = TimeHelper.ClientNow() - self.startTime;

            self.CheckKey();
            self.CheckKeyUp();
            self.CheckKeyDown();
        }
    }
}