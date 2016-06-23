﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    //服务员
    public class Waiter
    {
        private IList<Command> orders = new List<Command>();

        //设置订单
        public void SetOrder(Command command)
        {
            if (command.ToString() == "命令模式.BakeChickenWingCommand")
            {
                Console.WriteLine("服务员：鸡翅没有了，请点别的烧烤。");
            }
            else
            {
                orders.Add(command);
                Console.WriteLine("增加订单：" + command.ToString() + "  时间：" + DateTime.Now.ToString());
            }
        }

        //取消订单
        public void CancelOrder(Command command)
        {
            orders.Remove(command);
            Console.WriteLine("取消订单：" + command.ToString() + "  时间：" + DateTime.Now.ToString());
        }

        //通知全部执行
        public void Notify()
        {
            foreach (Command cmd in orders)
            {
                cmd.ExcuteCommand();
            }
        }
    }

    //抽象命令
    public abstract class Command
    {
        protected Barbecuer receiver;

        public Command(Barbecuer receiver)
        {
            this.receiver = receiver;
        }

        //执行命令
        abstract public void ExcuteCommand();
    }

    //烤羊肉串命令
  public  class BakeMuttonCommand : Command
    {
        public BakeMuttonCommand(Barbecuer receiver)
            : base(receiver)
        { }

        public override void ExcuteCommand()
        {
            receiver.BakeMutton();
        }
    }

    //烤鸡翅命令
   public class BakeChickenWingCommand : Command
    {
        public BakeChickenWingCommand(Barbecuer receiver)
            : base(receiver)
        { }

        public override void ExcuteCommand()
        {
            receiver.BakeChickenWing();
        }
    }

    //烤肉串者
    public class Barbecuer
    {
        public void BakeMutton()
        {
            Console.WriteLine("烤羊肉串!");
        }

        public void BakeChickenWing()
        {
            Console.WriteLine("烤鸡翅!");
        }
    }
}
