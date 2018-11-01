using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace MyFirstCSharpSkill_Lambda
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            //Response�v���p�e�B��Alexa�ɒ��点����e�Ȃǂ�˂�����ł���
            var skillResponse = new SkillResponse
            {
                Version = "1.0",//����
                Response = new ResponseBody()//����
            };


            //���N�G�X�g�^�C�v���uLaunchRequest�v������ȊO�́uIntentRequest�v�����ʂ���
            //����̓X�L���N�����ɑ�����uLaunchRequest�v�̂Ƃ��Ƃ���ȊO�̂Ƃ��ňقȂ郌�X�|���X��Ԃ��悤�ɂ����B
            if (input.Request.Type == nameof(Alexa.NET.Request.Type.LaunchRequest))
            {
                skillResponse.Response.OutputSpeech = new PlainTextOutputSpeech
                {
                    Text = "�X�L�����N�����܂�����B"
                };
            }
            else
            {
                //
                skillResponse.Response.OutputSpeech = new PlainTextOutputSpeech
                {
                    Text = "�X�L�����N���ł��܂���ł�����B"
                };
            }


            //�Z�b�V�����I��������B
            skillResponse.Response.ShouldEndSession = true;

            return skillResponse;
        }
    }
}
