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
            //ResponseプロパティにAlexaに喋らせる内容などを突っ込んでいく
            var skillResponse = new SkillResponse
            {
                Version = "1.0",//お約束
                Response = new ResponseBody()//お約束
            };


            //リクエストタイプが「LaunchRequest」かそれ以外の「IntentRequest」か判別する
            //今回はスキル起動時に送られる「LaunchRequest」のときとそれ以外のときで異なるレスポンスを返すようにした。
            if (input.Request.Type == nameof(Alexa.NET.Request.Type.LaunchRequest))
            {
                skillResponse.Response.OutputSpeech = new PlainTextOutputSpeech
                {
                    Text = "スキルを起動しましたよ。"
                };
            }
            else
            {
                //
                skillResponse.Response.OutputSpeech = new PlainTextOutputSpeech
                {
                    Text = "スキルを起動できませんでしたよ。"
                };
            }


            //セッション終了させる。
            skillResponse.Response.ShouldEndSession = true;

            return skillResponse;
        }
    }
}
