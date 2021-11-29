using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidS
{
    public class ControllersProxy : IInitialization, IExecute, IFixedExecute, ILateExecute, ICleanup
    {
        private readonly List<IInitialization> _initializationControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<IFixedExecute> _fixedExecuteControllers;
        private readonly List<ILateExecute> _lateExecuteControllers;
        private readonly List<ICleanup> _cleanupControllers;

        public ControllersProxy()
        {
            _initializationControllers = new List<IInitialization>();
            _executeControllers = new List<IExecute>();
            _fixedExecuteControllers = new List<IFixedExecute>();
            _lateExecuteControllers = new List<ILateExecute>();
            _cleanupControllers = new List<ICleanup>();
        }

        public void Add(IController controller)
        {
            if (controller is IInitialization initController)
            {
                _initializationControllers.Add(initController);
            }

            if (controller is IExecute executeController)
            {
                _executeControllers.Add(executeController);
            }

            if (controller is IFixedExecute fixedExecuteController)
            {
                _fixedExecuteControllers.Add(fixedExecuteController);
            }

            if (controller is ILateExecute lateExecuteController)
            {
                _lateExecuteControllers.Add(lateExecuteController);
            }

            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }
        }

        public void Initialize()
        {
            foreach (IInitialization controller in _initializationControllers) 
                controller.Initialize();
        }

        public void Execute(float deltaTime)
        {
            foreach (IExecute controller in _executeControllers) 
                controller.Execute(deltaTime);
        }

        public void FixedExecute()
        {
            foreach (IFixedExecute controller in _fixedExecuteControllers) 
                controller.FixedExecute();
        }

        public void LateExecute()
        {
            foreach (ILateExecute controller in _lateExecuteControllers) 
                controller.LateExecute();
        }

        public void Cleanup()
        {
            foreach (ICleanup controller in _cleanupControllers) 
                controller.Cleanup();
        }

        
    }
}


