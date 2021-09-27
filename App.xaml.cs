using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static System.Threading.Mutex mutex;
        protected override void OnStartup(StartupEventArgs e)
        {
            #region 全局异常捕捉
            //全局异常捕捉  捕捉到未处理的子线程异常，可关闭程序或点击确认直接忽略。异常原因：
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;//Task异常 

            //UI线程未捕获异常处理事件（UI主线程）
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;

            //非UI线程未捕获异常处理事件(例如自己创建的一个子线程)
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            #endregion

            #region 避免多开
            mutex = new System.Threading.Mutex(true, "OnlyOne");
            if (mutex.WaitOne(0, false))
            {
                base.OnStartup(e);
            }
            else
            {
                MessageBox.Show("无法重复打开软件");
                this.Shutdown();
                //无法重启
            }
            #endregion
        }

        #region 异常捕捉事件
        /// <summary>
        /// 全局异常捕捉  捕捉到未处理的子线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            try
            {
                var exception = e.Exception as Exception;
                if (exception != null)
                {
                    MessageBox.Show($"【UI线程子线程异常】 {exception}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("【UI线程子线程异常】记录异常的时候" + ex.Message);
            }
            finally
            {
                e.SetObserved();
            }
        }

        /// <summary>
        /// UI线程未捕获异常处理事件（UI主线程）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                MessageBox.Show("【UI线程主线程异常】" + e?.Exception?.ToString() ?? "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("【UI线程主线程异常】记录异常的时候" + ex?.ToString() ?? "");
            }
            finally
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 非UI线程未捕获异常处理事件(例如自己创建的一个子线程)  只能做个异常记录  程序还是会崩溃
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var exception = e.ExceptionObject as Exception;
                if (exception != null)
                {
                    MessageBox.Show("【非UI线程子线程异常】" + exception.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("【非UI线程子线程异常】记录异常的时候" + ex?.ToString());
            }
            finally
            {
                //ignore
                
            }
        }

        
        #endregion
    }
}
